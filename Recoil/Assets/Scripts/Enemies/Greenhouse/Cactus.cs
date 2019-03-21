using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour {

    private GameObject player; 
    private PlayerHealth playerHP;

    public float stopWaitTime = 0.2f;
    public float timeBetweenSpeedChanges = 0.1f;

    public float startingSpeed = 100.0f;
    
    private float slowDownSpeed;
    private float speedUpSpeed;

    void Start() {           
        player = GameObject.Find("obj_player");
        playerHP = player.GetComponent<PlayerHealth>();

        slowDownSpeed = startingSpeed / 10;
        speedUpSpeed = (startingSpeed / 10) + 4;

        StartCoroutine(CactusPattern());
    }

    IEnumerator CactusPattern() {
        for (int i = 0; i < 10; i++) {
            yield return SlowDown();
        }
    
        yield return Stop();
        
        for (int i = 0; i < 15; i++) {
            yield return SpeedUp();
        }

        yield return Stop();
    }

    IEnumerator SlowDown() {
        StandardFireFunctions.FireVerticallyFakeGravity(gameObject, startingSpeed);
        startingSpeed = startingSpeed - slowDownSpeed;
        yield return new WaitForSeconds(timeBetweenSpeedChanges);
    }   

    IEnumerator SpeedUp() {
        StandardFireFunctions.FireDownFakeGravity(gameObject, startingSpeed);
        startingSpeed = startingSpeed + speedUpSpeed;
        yield return new WaitForSeconds(timeBetweenSpeedChanges);
    }  

    IEnumerator Stop() {
        StandardFireFunctions.StopFire(gameObject);

        yield return new WaitForSeconds(stopWaitTime);
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            playerHP.TakeDamage();   
        } else if (collision.gameObject.name == "obj_pot") {
            Destroy(gameObject);
        }
    }

}
