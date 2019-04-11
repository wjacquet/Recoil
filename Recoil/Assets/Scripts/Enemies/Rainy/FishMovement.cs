using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour {

    public float speed = 50.0f;

    GameObject player;
    PlayerHealth playerHP;

    private bool left = true;

    void Start() {
        player = GameObject.Find("obj_player");
        playerHP = player.GetComponent<PlayerHealth>();
    }

    void Update() {        
        if (left) {
            StandardFireFunctions.FireLeft(gameObject, speed);
            gameObject.transform.localScale = new Vector2(1, gameObject.transform.localScale.y);        
        } else {
            StandardFireFunctions.FireRight(gameObject, speed);
            gameObject.transform.localScale = new Vector2(-1, gameObject.transform.localScale.y);        
        }

    }

    void FlipFish() {
        left = !left;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Player") {
            playerHP.TakeDamage();   
        } 
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Ground") {
            FlipFish();
        } 
    }
}
