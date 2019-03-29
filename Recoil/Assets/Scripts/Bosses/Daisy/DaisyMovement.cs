using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaisyMovement : MonoBehaviour
{
    public GameObject petals;
    public GameObject bullet;
    public GameObject laser;
    public GameObject warningLaser;
    private PlayerHealth playerHP;
    private float angle = 0;
    private float rotationSpeed = 1f;
    private int minX = 272;
    private int maxX = 488;
    private int minY = -72;
    private int maxY = 72;
    private Vector3 origin;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FlowerPatterns());
        origin = transform.position;

        GameObject player = GameObject.Find("obj_player");
        playerHP = player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        petals.transform.Rotate(0, 0, rotationSpeed);
        angle += rotationSpeed;
        if (angle >= 360)
            angle = angle % 360;
    }

    IEnumerator FlowerPatterns() {
        while (true) {
            // shooting burst attack
            yield return CircularBurst();
            // bounce attack
            yield return BounceAttack();
            // laser attack
            yield return LaserAttack();
            // wind attack
            // pedal attack
        }
    }

    IEnumerator CircularBurst() {
        rotationSpeed = 1f;

        Rigidbody2D rigidBody;
        Vector2 directions = Vector2.one; 
        int angleOffset = 45;

        // shoot 12 bursts
        for (int j = 0; j <= 12; j++) {
            // shoot a circular burst, similar to the mine
            for (int i = 0; i <= 8; i++,directions = Vector2.one) {
                float angleToPlayer = Mathf.Atan2(directions.x,directions.y);
                angleToPlayer = Mathf.Rad2Deg * angleToPlayer;
                angleToPlayer += angleOffset * i;
                angleToPlayer += (int)angle;

                directions.x = Mathf.Sin(Mathf.Deg2Rad * angleToPlayer);
                directions.y = Mathf.Cos(Mathf.Deg2Rad * angleToPlayer);

                directions.Normalize();
                Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + 2);
                rigidBody = Instantiate(bullet, spawnPosition, transform.rotation).GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
                rigidBody.velocity = directions * 60;
            }

            yield return new WaitForSeconds(1.0f);
        }

        yield return new WaitForSeconds(2.0f);
    }

    IEnumerator BounceAttack() {
        rotationSpeed = 4f;

        float xComponent = 1.0f;
        float yComponent = 4.0f;
        Rigidbody2D rigidBody = gameObject.GetComponent<Rigidbody2D>();

        for (int i = 0; i < 1200; i++) {
            // bounce off of walls
            if (transform.position.x > maxX)
                xComponent = Mathf.Abs(xComponent) * -1;
            if (transform.position.y > maxY)
                yComponent = Mathf.Abs(yComponent) * -1;
            if (transform.position.x < minX)
                xComponent = Mathf.Abs(xComponent);
            if (transform.position.y < minY)
                yComponent = Mathf.Abs(yComponent);
            
            // set velocity
            Vector2 direction = new Vector2(xComponent, yComponent);
            direction.Normalize();
            rigidBody.velocity = direction * 160;

            yield return null;
        }

        // move back to origin
        rigidBody.velocity = new Vector2(0, 0);
        yield return new WaitForSeconds(0.5f);
        while (transform.position != origin) {
            transform.position = Vector2.MoveTowards(transform.position, origin, 60 * Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSeconds(2.0f);
    }

    IEnumerator LaserAttack() {
        rotationSpeed = 0.5f;
        int angleOffset = 45;

        // spawn warning lasers
        GameObject[] lasers = new GameObject[8];
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + 3);
        for (int i = 0; i < 8; i++) {
            lasers[i] = Instantiate(warningLaser, transform.position, transform.rotation);
            lasers[i].GetComponent<Laser>().SetAngle((angleOffset * i) + (int)angle);
        }

        yield return new WaitForSeconds(2.0f);

        // delete warning lasers
        for (int i = 0; i < 8; i++) {
            Destroy(lasers[i]);
        }

        // spawn lasers
        for (int i = 0; i < 8; i++) {
            lasers[i] = Instantiate(laser, transform.position, transform.rotation);
            lasers[i].GetComponent<Laser>().SetAngle((angleOffset * i) + (int)angle);
        }

        yield return new WaitForSeconds(8.0f);

        // delete lasers
        for (int i = 0; i < 8; i++) {
            Destroy(lasers[i]);
        }

        yield return new WaitForSeconds(2.0f);
    }

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.tag == "Player") {
            playerHP.TakeDamage();
        }
    }
}
