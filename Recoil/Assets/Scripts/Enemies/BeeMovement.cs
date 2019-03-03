using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeMovement : MonoBehaviour {

    GameObject player;
    PlayerHealth playerHP;
    
    // Refrence to sprite used to flip horizontally
    public SpriteRenderer mySpriteRenderer;
    
    // True = Clockwise
    // False = CounterClockwise
    public bool clockwise = true;
    public float rotateSpeed = 3f;
    public float radius = 40f;
 
    private Vector2 center;
    private float angle;

    void Start() {
        // Set players health at start
        player = GameObject.Find("obj_player");
        playerHP = player.GetComponent<PlayerHealth>();

        // Find where the center of the bee circle is
        center = transform.position;
    }

    void Update() {
        if(clockwise)
            rotateClockwise();
        else    
            rotateCounterClockwise();
    }

    void rotateClockwise() {
        angle += rotateSpeed * Time.deltaTime;
 
        var offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * radius;
        transform.position = center + offset;

        // Face where they are going
        transform.up =  offset;
    }

    void rotateCounterClockwise() {
        angle += rotateSpeed * Time.deltaTime;
 
        var offset = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * radius;
        transform.position = center + offset;

        // Flip sprite 
        mySpriteRenderer.flipX = true;
        
        // Face where they are going
        transform.up =  offset;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            playerHP.TakeDamage();   
        }
    }
}
