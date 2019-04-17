using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour {

    GameObject player;
    PlayerHealth playerHP;

    public Rigidbody2D rigidBody;
    public int fractionSpeed = 25;
    public float timeBetween = 1.0f;

    private Vector2 center;
    private bool left;

    float amplitudeX = 5.0f;
    float amplitudeY = 20.0f;
    float omegaX = 5.0f;
    float omegaY = 10.0f;
    float index;

    void Start() {
        player = GameObject.Find("obj_player");
        playerHP = player.GetComponent<PlayerHealth>();

        // StartCoroutine(HoverPattern());
        rigidBody = gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
    }

    void Update() {
        index += Time.deltaTime;
        // float x = amplitudeX*Mathf.Cos (omegaX*index);
        float y = Mathf.Abs (amplitudeY*Mathf.Sin (omegaY*index));
        transform.localPosition= new Vector3(0,y,0);
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

    void FlipSnake() {
        left = !left;
    }

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

        if (LayerMask.LayerToName(collision.gameObject.layer) == "Ground") {
            FlipSnake();
        } 
    }

}
