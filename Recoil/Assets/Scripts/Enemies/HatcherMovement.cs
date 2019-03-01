using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatcherMovement : MonoBehaviour {
    
    public GameObject hatcher;
    GameObject player;
    PlayerHealth playerHP;

    private bool jump = false;
    private int timer = 100;
    Rigidbody2D rigidBody;
    
    // Start is called before the first frame update
    void Start() {
        GameObject player = GameObject.Find("obj_player");
        playerHP = player.GetComponent<PlayerHealth>();

        rigidBody = gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        rigidBody.freezeRotation = true;   
    }

    // Update is called once per frame
    void Update() {

        facePlayer();
       
        if (jump) {
            if (timer > 0) {
                timer--;

            }

            if (timer == 0) {
                timer = 100;
                jump = false;

                // Stop Movement once timer ends
                Rigidbody2D rigidBody = hatcher.GetComponent<Rigidbody2D>();
                rigidBody.velocity = new Vector2(0, 0);
            }
        
        } else {
          
            StandardFireFunctions.FireAtPlayer(hatcher);

        }    
    }

    void facePlayer() {
        player = GameObject.Find("obj_player");
        Vector2 direction = new Vector2(
            player.transform.position.x - transform.position.x,
            player.transform.position.y - transform.position.y
        );

        transform.up = direction;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            playerHP.TakeDamage();
            jump = true;  
                       
            StandardFireFunctions.FireDegreeOffsetFromPlayer(hatcher, 180);

        } 
    }

}
