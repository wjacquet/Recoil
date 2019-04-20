using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    public GameObject hatcher;
    GameObject player;
    PlayerHealth playerHP;
    Rigidbody2D rigidBody;

    private bool jump = false;
    private bool rotating = false;
    private Vector3 rotationVector = new Vector3(0,0,1);

    public int speed = 70;
    
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
            StandardFireFunctions.FireAtPlayerWithSetSpeed(hatcher, speed);

        if (rotating)
            transform.RotateAround(player.transform.position, rotationVector, 100*Time.deltaTime);

    }

    IEnumerator Timer() {
        yield return new WaitForSeconds(0.75f);
        jump = false;
        yield return new WaitForSeconds(1.5f);
        rotating = false;
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
            rotating = true;
            jump = true;  
            StandardFireFunctions.FireDegreeOffsetFromPlayer(hatcher, 180);
            StartCoroutine(Timer());
        }
        if (collision.gameObject.layer == 10 && rotating) { // Layer 10 == Ground
            rotationVector = new Vector3(0,0,-rotationVector.z);
        } 
    }

}