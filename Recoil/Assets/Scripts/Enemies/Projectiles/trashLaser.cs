using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashLaser : MonoBehaviour
{
    PlayerHealth playerHP;

    private int speed = 60;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("obj_player");
        playerHP = player.GetComponent<PlayerHealth>();
    }

    void LeftLaser()
    {
        Rigidbody2D rigidBody = gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;

        // Find player and find the direction vector
        GameObject player = GameObject.Find("obj_player");
        playerHP = player.GetComponent<PlayerHealth>();
        Vector2 direction = Vector2.left;

        direction.Normalize();
        rigidBody.velocity += direction * speed;
    }

    void RightLaser()
    {
        Rigidbody2D rigidBody = gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;

        // Find player and find the direction vector
        GameObject player = GameObject.Find("obj_player");
        playerHP = player.GetComponent<PlayerHealth>();
        Vector2 direction = Vector2.right;

        direction.Normalize();
        rigidBody.velocity += direction * speed;
    }

    // Once the projectile hits a wall
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHP.TakeDamage();
        }
        Destroy(gameObject);
    }
}
