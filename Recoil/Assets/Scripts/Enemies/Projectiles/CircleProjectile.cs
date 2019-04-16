using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleProjectile : MonoBehaviour {

    PlayerHealth playerHP;

    public float speed = 50.0f;
    public float timeCounter = 0;

    private float angle = 0.0f;
    private float radius = 10.0f;

    void Start() {
        GameObject player = GameObject.Find("obj_player");
        playerHP = player.GetComponent<PlayerHealth>();
    }

    void CircleFire() {
        // StartCoroutine(CirclePattern());
    }

    void Update() {
        timeCounter += Time.deltaTime;
        radius += 0.1f;

        float x = Mathf.Cos(timeCounter) * radius;
        float y =  Mathf.Sin(timeCounter) * radius;
        float z = 0;

        transform.position = new Vector3(x, y, z);
    }

    // IEnumerator CirclePattern() {
    //     while (true) {
    //         angle = angle + 1.0f;
    //         ResetAngle();
    //         yield return Shoot();
    //     }
    // }

    // IEnumerator Shoot() {
    //     StandardFireFunctions.FireInCircle(gameObject, speed, angle, radius);

    //     yield return new WaitForSeconds(0.01f);
    // }

    // void ResetAngle() {
    //     if (angle >= 360.0f) {
    //         angle = 0.0f;
    //     }
    // }

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
