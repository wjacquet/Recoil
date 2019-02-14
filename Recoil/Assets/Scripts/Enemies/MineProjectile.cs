using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bullet;

    // Update is called once per frame
    void Explode()
    {
        //Rigidbody2D rigidBody = gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;

        // Find player and find the direction vector
        Rigidbody2D rigidBody;
        Vector2 directions = new Vector2(1.0f, 1.0f); //= player.transform.position - transform.position;
        int angleOffset = 30;
        for (int i = 0; i <= 12; i++) {
            print("We shoot" + i);
            float angleToPlayer = Mathf.Atan2(directions.x,directions.y);
            angleToPlayer = Mathf.Rad2Deg * angleToPlayer;
            angleToPlayer += angleOffset * i;

            directions.x = Mathf.Sin(Mathf.Deg2Rad * angleToPlayer);
            directions.y = Mathf.Cos(Mathf.Deg2Rad * angleToPlayer);

            directions.Normalize();
            rigidBody = Instantiate(bullet, transform.position, transform.rotation).GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
            rigidBody.velocity = directions;
        }
    }

    // If the mine comes into contact with anything else
    void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Bullet") {
            print("Kaboom !!!");
            Explode();
        }

        Destroy(gameObject);
    }
}
