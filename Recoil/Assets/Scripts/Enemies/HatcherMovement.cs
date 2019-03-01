using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatcherMovement : MonoBehaviour {
    
    public GameObject hatcher;
    GameObject player;
    PlayerHealth playerHP;

    private bool jump = false;
    private int timer = 100;
    private Vector2 direction;
    
    // Start is called before the first frame update
    void Start() {
        GameObject player = GameObject.Find("obj_player");
        playerHP = player.GetComponent<PlayerHealth>();   
    }

    // Update is called once per frame
    void Update() {
        if (jump) {
            if (timer > 0) {
                timer--;

            }

            if (timer == 0) {
                timer = 100;
                jump = false;

                // Stop Movement once timer ends
                Rigidbody2D rigidBody = hatcher.GetComponent<Rigidbody2D>();
                direction.Normalize();
                rigidBody.velocity = new Vector2(0, 0);
            }
        
        } else {
            player = GameObject.Find("obj_player");
            Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, playerPos, 75 * Time.deltaTime);

        }    
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            playerHP.TakeDamage();
            jump = true;  
            
           
            StandardFireFunctions.FireDegreeOffsetFromPlayer(hatcher, 180);


        } 
    }

}
