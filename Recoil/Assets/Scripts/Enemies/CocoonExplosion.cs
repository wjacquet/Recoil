using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocoonExplosion : MonoBehaviour {

    public GameObject hatcher;


    void Explode() {

        StandardFireFunctions.FireAtPlayer(Instantiate(hatcher, transform.position, transform.rotation));

    }

    // If the pod comes into contact with anything else
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "Player") {
            // print("Kaboom !!!");
            Destroy(gameObject);
            Explode();
        }
    }

}
