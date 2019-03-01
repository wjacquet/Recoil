using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocoonExplosion : MonoBehaviour {

    // If the pod comes into contact with anything else
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "Player") {
            print("Kaboom !!!");
            // Explode();
            Destroy(gameObject);
        }
    }

}
