using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pillarHead : MonoBehaviour
{
    PlayerHealth playerHP;

    private int speed = 60;
    private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("obj_player");
        playerHP = player.GetComponent<PlayerHealth>();
    }

    void PopPillar()
    {
        Rigidbody2D rigidBody = gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;

        // Find player and find the direction vector
        GameObject player = GameObject.Find("obj_player");
        playerHP = player.GetComponent<PlayerHealth>();
        direction = Vector2.up;

        direction.Normalize();
        rigidBody.velocity += direction * speed;
    }

    void flipDirection ()
    {
        Rigidbody2D rigidBody = gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;

        //Debug.Log("FLIPPING");

        if (direction == Vector2.up)
        {
            direction = Vector2.down;
            direction.Normalize();
            rigidBody.velocity += direction * speed;
        } else
        {
            direction = Vector2.up;
            direction.Normalize();
            rigidBody.velocity += direction * speed;
        }
    }

    // Once the projectile hits a wall
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHP.TakeDamage();
            
        }
        else if (collision.gameObject.name == "obj_pot")
        {
            flipDirection();
        }
        flipDirection();
    }
}
