using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiranhaVerticalJump : MonoBehaviour
{
    Rigidbody2D rigidBody;
    PlayerHealth playerHP;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        rigidBody.velocity = Vector2.up * 150f;

        GameObject player = GameObject.Find("obj_player");
        playerHP = player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // gravity
        rigidBody.velocity += Vector2.down * 1.0f;
        
        // kill if below water
        if (transform.position.y < -200) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Player") {
            playerHP.TakeDamage();   
        }
    }
}
