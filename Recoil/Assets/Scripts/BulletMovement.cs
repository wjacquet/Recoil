using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    float knockback = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rigidBody = gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;

        // Find the cursor and find the direction vector
        GameObject cursor = GameObject.Find("obj_cursor");
        Vector2 direction = cursor.transform.position - transform.position;
        direction.Normalize();
        rigidBody.velocity = direction;

        // Player recoil
        GameObject player = GameObject.Find("obj_player");
        Vector2 recoil = new Vector2(-direction.x, -direction.y) * knockback;
        player.GetComponent<PlayerMovement>().Recoil(recoil);
    }

        // Once the projectile hits a wall
    void OnCollisionEnter2D(Collision2D collision) 
    {
        Destroy(gameObject);
    }
}
