using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerHealth playerHP;
    void Start()
    {
        Rigidbody2D rigidBody = gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;

        // Find player and find the direction vector
        GameObject player = GameObject.Find("obj_player");
        playerHP = player.GetComponent<PlayerHealth>();
        Vector2 direction = player.transform.position - transform.position;
        direction.y = 0;
        direction.Normalize();
        rigidBody.velocity = direction;
    }

    // Once the projectile hits a wall
    void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Player") {
            playerHP.TakeDamage();
        }
        Destroy(gameObject);
    }

}
