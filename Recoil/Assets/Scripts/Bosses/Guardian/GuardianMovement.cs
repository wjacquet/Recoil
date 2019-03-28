using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianMovement : MonoBehaviour
{
    //positions
    private Vector3 startLocation = new Vector3(-1700, 512, 0);
    private Vector3 leftLocation = new Vector3(-1850, 512, 0);
    private Vector3 rightLocation = new Vector3(-1550, 512, 0);

    private bool bossStarted = false;

    //shots
    public GameObject eyeshot;
    public GameObject homingBall;

    void Update()
    {
        // Boss enters the arena
        if (transform.position.x != startLocation.x)
        {
            transform.position = Vector2.MoveTowards(transform.position, startLocation, 240 * Time.deltaTime);
            //Debug.Log("if");
            return;
        }
        else if (!bossStarted && transform.position.x == startLocation.x)
        {
            //Debug.Log("else");
            bossStarted = true;
            StartCoroutine(BossPatterns());
        }
    }

    IEnumerator BossPatterns()
    {
        while (true)
        {
            yield return Move();
            yield return Overload();
            yield return new WaitForSeconds(2.0f);
        }
    }

    IEnumerator Overload()
    {
        Instantiate(homingBall, transform.position, transform.rotation);
        StandardFireFunctions.FireAtPlayer(Instantiate(eyeshot, transform.position, transform.rotation));
        StandardFireFunctions.FireDegreeOffsetFromPlayer(Instantiate(eyeshot, transform.position, transform.rotation), 20);
        StandardFireFunctions.FireDegreeOffsetFromPlayer(Instantiate(eyeshot, transform.position, transform.rotation), -20);

        yield return new WaitForSeconds(3.0f);
    }

    IEnumerator Move()
    {
        Vector3 newPosition = startLocation;
        switch (Random.Range(0, 2))
        {
            case 0:
                Debug.Log("pickleft");
                newPosition = leftLocation;
                break;
            case 1:
                Debug.Log("pickright");
                newPosition = rightLocation;
                break;
        }

        if (transform.position == newPosition)
        {
            Debug.Log("picked same: waiting");
            // If the same position is choosen, wait two seconds
            yield return new WaitForSeconds(2.0f);
        }
        else
        {
            // set the speed to go to the next position
            int speed = 30;
            if (Mathf.Abs(newPosition.y - transform.position.y) > 100)
            {
                speed = 60;
            }

            // move to a new position
            while (transform.position != newPosition)
            {
                Debug.Log("moving to new pos");
                transform.position = Vector2.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
                yield return null;
            }
        }
    }
}
