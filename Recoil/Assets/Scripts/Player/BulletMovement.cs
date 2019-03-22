using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private int knockback = 30;
    private int speed = 100;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rigidBody = gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;

        // Find the cursor and find the direction vector
        GameObject cursor = GameObject.Find("obj_cursor");
        Vector2 direction = cursor.transform.position - transform.position;
        direction.Normalize();
        rigidBody.velocity = direction * speed;

        // Player recoil
        GameObject player = GameObject.Find("obj_player");
        Vector2 recoil = new Vector2(-direction.x, -direction.y) * knockback;
        player.GetComponent<PlayerMovement>().Recoil(recoil);
    }

        // Once the projectile hits a wall
    void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Enemy") {
            collision.gameObject.GetComponent<EnemyHealth>().Damage();
        }

        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.tag == "Enemy") {
            collision.gameObject.GetComponent<EnemyHealth>().Damage();
            Destroy(gameObject);
        }
    }
}
