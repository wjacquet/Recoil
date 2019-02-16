using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bullet;

    private int speed = 100;
    // Update is called once per frame
    void Explode()
    {
        //Rigidbody2D rigidBody = gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;

        // Find player and find the direction vector
        Rigidbody2D rigidBody;
        Vector2 directions = Vector2.one; //= player.transform.position - transform.position;
        int angleOffset = 30;
        for (int i = 0; i <= 12; i++,directions = Vector2.one) {
            float angleToPlayer = Mathf.Atan2(directions.x,directions.y);
            angleToPlayer = Mathf.Rad2Deg * angleToPlayer;
            angleToPlayer += angleOffset * i;

            directions.x = Mathf.Sin(Mathf.Deg2Rad * angleToPlayer);
            directions.y = Mathf.Cos(Mathf.Deg2Rad * angleToPlayer);

            directions.Normalize();
            rigidBody = Instantiate(bullet, transform.position, transform.rotation).GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
            rigidBody.velocity = directions * speed;
        }
    }

    // If the mine comes into contact with anything else
    void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "Player") {
            print("Kaboom !!!");
            Explode();
            Destroy(gameObject);
        }


    }
}
