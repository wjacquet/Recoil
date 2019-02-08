using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimedProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 diagonalUp;
    private Vector2 diagonalDown;
    
    void Start()
    {
        Rigidbody2D rigidBody = gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;

        // Find player and find the direction vector
        GameObject player = GameObject.Find("obj_player");
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        rigidBody.velocity += direction;
    }

    void DiagonalOffset(bool up) 
    {
        Rigidbody2D rigidBody = gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        Vector2 dir = rigidBody.velocity;

    
        if (up) {
            dir.y += Mathf.Sin(Mathf.Deg2Rad * 15);
            dir.x += Mathf.Cos(Mathf.Deg2Rad * 15);
        }
        else { 
            dir.y += Mathf.Sin(Mathf.Deg2Rad * -15);
            dir.x += Mathf.Cos(Mathf.Deg2Rad * -15);
        }

        dir.Normalize();
        rigidBody.velocity = dir;

    }

    // Once the projectile hits a wall
    void OnCollisionEnter2D(Collision2D collision) 
    {
        Destroy(gameObject);
    }
}
