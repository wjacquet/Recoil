using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticBlock : MonoBehaviour {

    public GameObject block;
    private bool magnet = false;

    Rigidbody2D rigidBody;

    void Start() {
        rigidBody = block.GetComponent<Rigidbody2D>();
    }
    
    void Update() {
        // If Right clicked, flip bool
        // if(Input.GetMouseButtonDown(1)) {
        //     magnet = !magnet;
        // }

        if (magnet) {
            StandardFireFunctions.MagnetTowardsPlayer(block, 10);
        } else {
            // StandardFireFunctions.StopFire(block);            
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        magnet = true;
    }

    void OnCollisionExit2D(Collision2D collision) {
        magnet = false;
    }
}
