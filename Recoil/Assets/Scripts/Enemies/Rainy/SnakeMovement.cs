using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
    How to use the snake in unity

    1. Put the obj_snake_head into scene
    2. Put 4 obj_snake_bodies into the scene
    3. On each body, there is a distance from head to set.
        a. Set the first body (The one directly bethind the head) = 20
        b. Second body = 40
        c. Third Body = 60
 */

public class SnakeMovement : MonoBehaviour {

    GameObject player;
    PlayerHealth playerHP;

    public Rigidbody2D rigidBody;

    private float amplitudeY = 30.0f;
    private float omegaY = 5.0f;
    private float index;
    private bool flip = false;

    void Start() {
        player = GameObject.Find("obj_player");
        playerHP = player.GetComponent<PlayerHealth>();

        rigidBody = gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = !flip;
    }

    void Update() {
        if (!flip) {
            MoveRight(Mathf.PI * 10);
        } else {
            MoveRight(-(Mathf.PI * 10));
        }
    }

    void MoveRight(float x) {
        index += 0.5f * Time.deltaTime;
        float y;

        y = amplitudeY * Mathf.Sin(omegaY * index);

        Vector2 direction = new Vector2(x, y);
        float speed = 0.8f;

        rigidBody.velocity = direction * speed;
    }

    void FlipSnake() {
        gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = flip;
        flip = !flip;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Player") {
            playerHP.TakeDamage();   
        } 

        if (LayerMask.LayerToName(collision.gameObject.layer) == "Ground") {
            FlipSnake();
        } 
    }

}
    