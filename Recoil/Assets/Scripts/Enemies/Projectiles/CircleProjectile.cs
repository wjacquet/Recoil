using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleProjectile : MonoBehaviour {

    PlayerHealth playerHP;
    UrchinShoot urchin;

    // private float timeCounter = 0;
    private float speed = 25.0f;
    // private Vector2 center;
// 
    private bool oneBool = false;
    private bool twoBool = false;
    private bool threeBool = false;
    private bool fourBool = false;

    void Start() {
        GameObject player = GameObject.Find("obj_player");
        playerHP = player.GetComponent<PlayerHealth>();
        
        urchin = GameObject.Find("obj_urchin").GetComponent<UrchinShoot>();
        // center = transform.position;
    }

    void one() {
        oneBool = true;
    }

    void two() {
        twoBool = true;
    }

    void three() {
        threeBool = true;
    }

    void four() {
        fourBool = true;
    }

    void FixedUpdate() {
        // timeCounter += Time.deltaTime;
        Vector2 offset;
        if (oneBool) {
            offset = new Vector3(Mathf.Cos(urchin.timeCounter1) * urchin.radius, Mathf.Sin(urchin.timeCounter1) * urchin.radius);
        } else if (twoBool) {
            offset = new Vector3(Mathf.Cos(urchin.timeCounter2) * urchin.radius, Mathf.Sin(urchin.timeCounter2) * urchin.radius);
        } else if (threeBool) {
            offset = new Vector3(Mathf.Cos(urchin.timeCounter3) * urchin.radius, Mathf.Sin(urchin.timeCounter3) * urchin.radius);
        } else if (fourBool) {
            offset = new Vector3(Mathf.Cos(urchin.timeCounter4) * urchin.radius, Mathf.Sin(urchin.timeCounter4) * urchin.radius);
        } else {
            offset = new Vector3(0,0,0);
        }

        transform.position = urchin.center + offset;
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
