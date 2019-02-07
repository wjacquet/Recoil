using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rigidBody = gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;

        // Find player and find the direction vector
        GameObject cursor = GameObject.Find("obj_player");
        Vector2 direction = cursor.transform.position - transform.position;
        direction.y = 0;
        direction.Normalize();
        rigidBody.velocity = direction;
    }

    // Once the projectile hits a wall
    void OnCollisionEnter2D(Collision2D collision) 
    {
        print("Colliding");
        Destroy(gameObject);
    }
}
