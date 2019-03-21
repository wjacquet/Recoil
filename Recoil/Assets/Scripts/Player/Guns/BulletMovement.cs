using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private int speed = 100;
    private int damage = 1;

    public Vector2 FireBullet() {
        Rigidbody2D rigidBody = gameObject.GetComponent<Rigidbody2D>();

        // Find the cursor and find the direction vector
        GameObject cursor = GameObject.Find("obj_cursor");
        Vector2 direction = cursor.transform.position - transform.position;
        direction.Normalize();
        rigidBody.velocity = direction * speed;

        return new Vector2(-direction.x, -direction.y);
    }

    // Once the projectile hits a wall
    void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Enemy") {
            collision.gameObject.GetComponent<EnemyHealth>().Damage(damage);
        }

        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.tag == "Enemy") {
            collision.gameObject.GetComponent<EnemyHealth>().Damage(damage);
        }

        Destroy(gameObject);
    }

    public void SetDamage(int dam) {
        damage = dam;
    }
}
