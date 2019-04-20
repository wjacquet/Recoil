using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleProjectile : MonoBehaviour {

    PlayerHealth playerHP;
    // UrchinShoot urchinShoot;

    private float timeCounter = 0;

    public float radius = 0.5f;
    public Vector2 center;


    void Start() {
        GameObject player = GameObject.Find("obj_player");
        playerHP = player.GetComponent<PlayerHealth>();
        
        // urchinShoot = GameObject.Find("obj_urchin").GetComponent<UrchinShoot>();
        center = transform.position;
    }

    void topRight() {
        timeCounter = 0;    
    }

    void topLeft() {
        timeCounter = 3.14159f/2.0f;
    }

    void bottomLeft() {
        timeCounter = 3.14159f;
    }

    void bottomRight() {
        timeCounter = 3.0f * 3.14159f / 2.0f;
    }

    void Update() {
        radius += 0.5f;
        timeCounter += 0.8f * Time.deltaTime;
        Vector2 offset = new Vector2(Mathf.Cos(timeCounter) * radius, Mathf.Sin(timeCounter) * radius);
        transform.position = center + offset;
    }

    // Once the projectile hits a wall
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            playerHP.TakeDamage();
        }
        if (collision.gameObject.tag != "Enemy" && collision.gameObject.tag != "Fan" && collision.gameObject.tag != "Scenery") {
            Destroy(gameObject);
        }
    }

}
