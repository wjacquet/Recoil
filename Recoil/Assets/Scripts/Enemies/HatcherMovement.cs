using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatcherMovement : MonoBehaviour {
    
    public GameObject hatcher;
    GameObject player;
    PlayerHealth playerHP;
    Rigidbody2D rigidBody;

    private bool jump = false;
    
    // Start is called before the first frame update
    void Start() {
        GameObject player = GameObject.Find("obj_player");
        playerHP = player.GetComponent<PlayerHealth>();
        rigidBody = gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        rigidBody.freezeRotation = true;   
    }

    // Update is called once per frame
    void Update() {

        // Make spider face player at all times
        facePlayer();
  
        // Move towards player
        if (!jump)  
            StandardFireFunctions.FireAtPlayer(hatcher);
    }

    IEnumerator Timer() {
        yield return new WaitForSeconds(1.2f);
        jump = false;
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
            StartCoroutine(Timer());
        } 
    }

}
