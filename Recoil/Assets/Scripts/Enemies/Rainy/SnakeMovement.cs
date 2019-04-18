using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour {

    GameObject player;
    PlayerHealth playerHP;

    public Rigidbody2D rigidBody;
    public int fractionSpeed = 25;
    public float timeBetween = 1.0f;

    // private Vector2 center;
    private bool left;

    float amplitudeX = 20.0f;
    float amplitudeY = 20.0f;
    float omegaX = 5.0f;
    float omegaY = 5.0f;
    float index;

    private Vector2 center;

    void Start() {
        player = GameObject.Find("obj_player");
        playerHP = player.GetComponent<PlayerHealth>();

        // StartCoroutine(HoverPattern());
        rigidBody = gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        center = transform.localPosition;
    }

    void Update() {
        if (Mathf.Abs(center.x - transform.localPosition.x) <= 50) {
            MoveRight();
        } else {
            MoveLeft();
        }
    }

    void MoveRight() {
        index += Time.deltaTime;
        float x = 3.14159f * amplitudeX * index;
        float y = (amplitudeY * Mathf.Sin(omegaY * index));
        transform.localPosition = new Vector2(x, y);
    }

    void MoveLeft() {
        index += Time.deltaTime;
        float x = -3.14159f * amplitudeX * index;
        float y = (amplitudeY * Mathf.Sin(omegaY * index));
        transform.localPosition = new Vector2(x, y);
    }

    // void Update() {        
    //     if (left) {
    //         StandardFireFunctions.FireLeft(gameObject, 30.0f);
    //         gameObject.transform.localScale = new Vector2(1, gameObject.transform.localScale.y);        
    //     } else {
    //         StandardFireFunctions.FireRight(gameObject, 30.0f);
    //         gameObject.transform.localScale = new Vector2(-1, gameObject.transform.localScale.y);        
    //     }
    // }

    // IEnumerator HoverPattern() {
    //     while (true) {
    //         yield return Hover(180);
    //         yield return Hover(-180);
    //     }
    // }

    // IEnumerator Hover(int yValue) {
    //     Vector2 movement = new Vector2(0, yValue);
    //     rigidBody.velocity = movement * 1/fractionSpeed;

    //     yield return new WaitForSeconds(timeBetween);
    // }
     
    void OnTriggerEnter2D(Collider2D collision) {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Player") {
            playerHP.TakeDamage();   
        } 
    }

}
