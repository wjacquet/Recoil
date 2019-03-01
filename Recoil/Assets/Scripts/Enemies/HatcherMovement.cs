using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatcherMovement : MonoBehaviour {
    
    public GameObject hatcher;
    GameObject player;
    PlayerHealth playerHP;

    private bool jump = false;
    private int timer = 100;
    
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
            
            Rigidbody2D rigidBody = gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
            // Find the cursor and find the direction vector
            player = GameObject.Find("obj_player");
            Vector2 direction = player.transform.position - transform.position;
            direction.Normalize();
            rigidBody.velocity = direction * speed;

            // Player recoil
            Vector2 recoil = new Vector2(-direction.x, -direction.y) * 30;
            player.GetComponent<PlayerMovement>().Recoil(recoil);

        } 
    }

}
