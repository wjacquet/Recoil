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
        print(direction.magnitude);
        rigidBody.velocity += direction;
    }

    void DiagonalOffset(bool up) 
    {
        Rigidbody2D rigidBody = gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        GameObject player = GameObject.Find("obj_player");
        Vector2 dir = player.transform.position - transform.position;
    
        if (up) {
            dir.y += Mathf.Sin(Mathf.Deg2Rad * 20);
            dir.x += Mathf.Cos(Mathf.Deg2Rad * 20);
        }
        else { 
            dir.y -= Mathf.Sin(Mathf.Deg2Rad * 20);
            dir.x -= Mathf.Cos(Mathf.Deg2Rad * 20);
        }

        dir.Normalize();
        print(dir.magnitude);
        rigidBody.velocity = dir;

    }

    // Once the projectile hits a wall
    void OnCollisionEnter2D(Collision2D collision) 
    {
        Destroy(gameObject);
    }
}
