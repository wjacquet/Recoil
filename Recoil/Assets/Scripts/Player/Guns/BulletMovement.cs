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

    public Vector2 FireClusterBullet() {
        
        Rigidbody2D rigidBody = gameObject.GetComponent<Rigidbody2D>();
        float spreadAngle = Random.Range(-8f, 8f);
        float speedModifier = Random.Range(0.65f, 1f);
        // Find the cursor and find the direction vector
        GameObject cursor = GameObject.Find("obj_cursor");
        Vector2 direction = cursor.transform.position - transform.position;
        float rotateAngle = spreadAngle + (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
        direction = new Vector2(Mathf.Cos(rotateAngle * Mathf.Deg2Rad), Mathf.Sin(rotateAngle * Mathf.Deg2Rad));
        direction.Normalize();
        rigidBody.velocity = direction * (speed * speedModifier);

        return new Vector2(-direction.x, -direction.y);
    }

    // Once the projectile hits a wall
    void OnCollisionEnter2D(Collision2D collision) 
    {
        string tag = collision.gameObject.tag;
        if (collision.gameObject.tag == "Enemy") {
            collision.gameObject.GetComponent<EnemyHealth>().Damage(damage);
        }
        if (tag != "Player" && tag != "Gun" && tag != "Bullet") {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision) 
    {
        string tag = collision.gameObject.tag;
        if (collision.gameObject.tag == "Enemy") {
            collision.gameObject.GetComponent<EnemyHealth>().Damage(damage);
        }
        if (tag != "Player" && tag != "Gun" && tag != "Bullet") {
            Destroy(gameObject);
        }
    }

    public void SetDamage(int dam) {
        damage = dam;
    }
}
