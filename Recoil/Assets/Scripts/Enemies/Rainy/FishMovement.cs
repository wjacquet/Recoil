using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour {

    GameObject player;
    PlayerHealth playerHP;

    private Vector2 center;
    private int distance = 1;
    private bool left = false;

    void Start() {
        player = GameObject.Find("obj_player");
        playerHP = player.GetComponent<PlayerHealth>();

        center = transform.position;
    }

    void Update() {
        Fly(distance);
        
        if (left) distance++;
        else distance--;
    }

    void Fly(int distance) { 
        var offset = new Vector2(distance, 0);
        transform.position = offset;
    }

    void FlipFish() {
        Debug.Log("FLIPPING FISH");
        left = !left;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log(LayerMask.LayerToName(collision.gameObject.layer));
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Player") {
            playerHP.TakeDamage();   
        } 
        
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Ground") {
            FlipFish();
        } 
    }
}
