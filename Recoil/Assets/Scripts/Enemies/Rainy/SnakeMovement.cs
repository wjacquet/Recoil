using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour {

    GameObject player;
    PlayerHealth playerHP;

    public Rigidbody2D rigidBody;
    public int fractionSpeed = 25;
    public float timeBetween = 1.0f;

    private bool left;

    float amplitudeY = 50.0f;
    float omegaY = 5.0f;
    float index;

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
        index += Time.deltaTime;
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
    