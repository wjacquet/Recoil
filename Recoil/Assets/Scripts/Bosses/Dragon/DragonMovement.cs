using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMovement : MonoBehaviour
{
    private Vector3 startLocation = new Vector3(-920, 184, 0);
    private Vector3 highLocation = new Vector3(-920, 240, 0);
    private Vector3 lowLocation = new Vector3(-920, 128, 0);
    private bool bossStarted = false;
    public GameObject fireball;
    public GameObject bomb;
    public GameObject laser;
    // Update is called once per frame
    void Update()
    {
        // Boss enters the arena
        if (transform.position.x != startLocation.x) {
            transform.position = Vector2.MoveTowards(transform.position, startLocation, 80 * Time.deltaTime);
            return;
        } else if (!bossStarted && transform.position.x == startLocation.x) {
            bossStarted = true;
            StartCoroutine(BossPatterns());
        }
    }

    IEnumerator BossPatterns() {
        while (true) {
            yield return ShootFireballs();
            yield return new WaitForSeconds(2.0f);
            yield return ShootExplosion();
            yield return ShootLaser();
        }
    }

    IEnumerator ShootLaser() {
        // choose a different position randomly
        Vector3 newPosition = startLocation;
        Vector3 nextPosition = startLocation;
        switch (Random.Range(0, 2)) {
            case 0:
                newPosition = highLocation;
                nextPosition = lowLocation;
                break;
            case 1:
                newPosition = lowLocation;
                nextPosition = highLocation;
                break;
        }

        // Move to top or bottom
        while (transform.position != newPosition) {
            transform.position = Vector2.MoveTowards(transform.position, newPosition, 30 * Time.deltaTime);
            yield return null;
        }

        // Shoot laser
        GameObject laserObj = Instantiate(laser, transform.position, transform.rotation);

        // Move up/down
        while (transform.position != nextPosition) {
            transform.position = Vector2.MoveTowards(transform.position, nextPosition, 40 * Time.deltaTime);
            if (laserObj != null) {
                laserObj.transform.position = new Vector3(transform.position.x + 256, transform.position.y, transform.position.z);
            }
            yield return null;
        }
        
        // Return to middle
        while (transform.position != startLocation) {
            transform.position = Vector2.MoveTowards(transform.position, startLocation, 30 * Time.deltaTime);
            yield return null;
        }
    }

    IEnumerator ShootExplosion() {
        Instantiate(bomb, transform.position, transform.rotation);
        yield return new WaitForSeconds(6.0f);
    }

    IEnumerator ShootFireballs() {
        for (int i = 0; i < 6; i++) {
            // choose a different position randomly
            Vector3 newPosition = startLocation;
            switch (Random.Range(0, 3)) {
                case 0:
                    newPosition = highLocation;
                    break;
                case 1:
                    newPosition = lowLocation;
                    break;
                case 2:
                    newPosition = startLocation;
                    break;
            }

            if (transform.position == newPosition) {
                // If the same position is choosen, wait two seconds
                yield return new WaitForSeconds(2.0f);
            } else {
                // set the speed to go to the next position
                int speed = 30;
                if (Mathf.Abs(newPosition.y - transform.position.y) > 100) {
                    speed = 60;
                }

                // move to a new position
                while (transform.position != newPosition) {
                    transform.position = Vector2.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
                    yield return null;
                }
            }

            // Shoot a fireball
            Instantiate(fireball, transform.position, transform.rotation);
        }

        while (transform.position != startLocation) {
            transform.position = Vector2.MoveTowards(transform.position, startLocation, 30 * Time.deltaTime);
            yield return null;
        }
    }
}
