using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticBlock : MonoBehaviour {

    public GameObject block;
    private bool magnet = false;
    private bool touching;

    Rigidbody2D rigidBody;

    void Start() {
        rigidBody = block.GetComponent<Rigidbody2D>();
    }
    
    void Update() {
        // If Right clicked, flip bool
        if(Input.GetMouseButtonDown(1)) {
            magnet = !magnet;
        }

        if (magnet && touching) {
            StandardFireFunctions.MagnetTowardsPlayer(block, 0.1f);
        } 
    }

    void OnCollisionEnter2D(Collision2D collision) {
        touching = true;
    }

    void OnCollisionExit2D(Collision2D collision) {
        touching = false;
    }
}
