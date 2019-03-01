using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocoonExplosion : MonoBehaviour {

    public GameObject hatcher;

    // Hatch the spider, movement of spider is in HatcherMovement
    void Hatch() {
        Rigidbody2D rigidBody;
        rigidBody = Instantiate(hatcher, transform.position, transform.rotation).GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
    }

    // If the pod comes into contact with anything else
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "Player") {
            // print("Kaboom !!!");
            Destroy(gameObject);
            Hatch();
        }
    }

}
