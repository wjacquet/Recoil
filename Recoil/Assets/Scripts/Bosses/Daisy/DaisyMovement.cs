using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaisyMovement : MonoBehaviour
{
    public GameObject petals;
    public GameObject bullet;
    private float angle = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FlowerPatterns());
    }

    // Update is called once per frame
    void Update()
    {
        petals.transform.Rotate(0, 0, 1f);
        angle += 1f;
        if (angle >= 360)
            angle = angle % 360;
    }

    IEnumerator FlowerPatterns() {
        while (true) {
            // shooting attack
            yield return CircularBurst();
            yield return new WaitForSeconds(1.0f);
            // laser attack
            // bounce attack
            // wind attack
            // pedal attack
        }
    }

    IEnumerator CircularBurst() {
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
                rigidBody = Instantiate(bullet, transform.position, transform.rotation).GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
                rigidBody.velocity = directions * 60;
            }

            yield return new WaitForSeconds(1.0f);
        }

        yield return new WaitForSeconds(2.0f);
    }
}
