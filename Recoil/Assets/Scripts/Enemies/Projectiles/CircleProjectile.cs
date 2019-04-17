using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleProjectile : MonoBehaviour {

    PlayerHealth playerHP;
    UrchinShoot urchin;

    private float timeCounter = 0;
    private float speed = 25.0f;

    public float radius = 0.5f;
    public Vector2 center;


    void Start() {
        GameObject player = GameObject.Find("obj_player");
        playerHP = player.GetComponent<PlayerHealth>();
        
        urchin = GameObject.Find("obj_urchin").GetComponent<UrchinShoot>();
        center = transform.position;
    }

    void one() {
        timeCounter = 120;    
    }

    void two() {
        timeCounter = 60;
    }

    void three() {
        timeCounter = 30;
    }

    void four() {
        timeCounter = 90;
    }

    void Update() {
        radius += 0.5f;
        timeCounter += 0.8f * Time.deltaTime;
        Vector2 offset = new Vector3(Mathf.Cos(timeCounter) * radius, Mathf.Sin(timeCounter) * radius);
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
