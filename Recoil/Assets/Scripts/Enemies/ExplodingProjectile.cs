using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingProjectile : MonoBehaviour
{
    PlayerHealth playerHP;
    private int speed = 85;
    private int maxDist = 250;
    void Start() 
    {
        GameObject player = GameObject.Find("obj_player");
        playerHP = player.GetComponent<PlayerHealth>();
    }

    void NormalFire()
    {
        Rigidbody2D rigidBody = gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;

        // Find player and find the direction vector
        GameObject player = GameObject.Find("obj_player");
        playerHP = player.GetComponent<PlayerHealth>();
        Vector2 direction = player.transform.position - transform.position;
        float dist, distRatio;

        direction.Normalize();
        
        if (direction.y < ((Vector2.one).normalized).y) {
            direction.y = ((Vector2.one).normalized).y;
            
            dist = Vector2.Distance(transform.position, player.transform.position);
            distRatio = dist > maxDist ? 1 : dist / maxDist;
            
            rigidBody.velocity += direction * (speed * (distRatio < 0.6f ? 0.65f : distRatio));
        } 
        else {
            rigidBody.velocity += direction * speed;
        }
        
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
