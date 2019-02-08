using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimedProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    void NormalFire()
    {
        Rigidbody2D rigidBody = gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;

        // Find player and find the direction vector
        GameObject player = GameObject.Find("obj_player");
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        rigidBody.velocity += direction;
    }

    void FireSpreadShot(int angleOffset)
    {
        Rigidbody2D rigidBody = gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;

        // Find player and find the direction vector
        GameObject player = GameObject.Find("obj_player");
        Vector2 direction = player.transform.position - transform.position;
        float angleToPlayer = Mathf.Atan2(direction.x,direction.y);
        angleToPlayer = Mathf.Rad2Deg * angleToPlayer;
        angleToPlayer += angleOffset;

        direction.x = Mathf.Sin(Mathf.Deg2Rad * angleToPlayer);
        direction.y = Mathf.Cos(Mathf.Deg2Rad * angleToPlayer);

        direction.Normalize();
        rigidBody.velocity = direction;
    }

    // Once the projectile hits a wall
    void OnCollisionEnter2D(Collision2D collision) 
    {
        Destroy(gameObject);
    }
}
