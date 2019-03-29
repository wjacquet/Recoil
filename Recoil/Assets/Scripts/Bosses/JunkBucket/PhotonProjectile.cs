using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonProjectile : MonoBehaviour
{
    public GameObject projectile;
    PlayerHealth playerHP;

    private int speed = 100;

    void Explode()
    {
        Rigidbody2D rigidBody;
        Vector2 directions = Vector2.one; 

        int angleOffset = 30;

        for (int i = 0; i <= 12; i++,directions = Vector2.one) {
            float angleToPlayer = Mathf.Atan2(directions.x,directions.y);
            angleToPlayer = Mathf.Rad2Deg * angleToPlayer;
            angleToPlayer += angleOffset * i;

            directions.x = Mathf.Sin(Mathf.Deg2Rad * angleToPlayer);
            directions.y = Mathf.Cos(Mathf.Deg2Rad * angleToPlayer);

            directions.Normalize();
            rigidBody = Instantiate(projectile, transform.position, transform.rotation).GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
            rigidBody.velocity = directions * speed;
        }
    }

    // If the mine comes into contact with anything else
    void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.tag != "Enemy" && collision.gameObject.tag != "Trap" && collision.gameObject.tag != "Bullet") {
            Explode();
            Destroy(gameObject);
        }
    }
}
