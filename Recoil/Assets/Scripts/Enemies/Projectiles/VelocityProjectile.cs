using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityProjectile : MonoBehaviour {
    
    PlayerHealth playerHP;
    
    public float speed = 5.0f;

    void Start() {
        GameObject player = GameObject.Find("obj_player");
        playerHP = player.GetComponent<PlayerHealth>();
    }

    void FireUp() {
        StartCoroutine(UpPattern());
    }

    void FireDown() {
        StartCoroutine(DownPattern());
    }

    IEnumerator UpPattern() {
        while (true) {
            yield return ShootUp();
        }
    }

    IEnumerator DownPattern() {
        while (true) {
            yield return ShootDown();
        }
    }

    IEnumerator ShootUp() {
        StandardFireFunctions.FireVerticallyFakeGravity(gameObject, speed);
        speed = speed + 1.0f;
        yield return new WaitForSeconds(0.01f);
    }

    IEnumerator ShootDown() {
        StandardFireFunctions.FireDownFakeGravity(gameObject, speed);
        speed = speed + 1.0f;
        yield return new WaitForSeconds(0.01f);
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            playerHP.TakeDamage();
        }
        if (collision.gameObject.tag != "Enemy" && collision.gameObject.tag != "Fan" && collision.gameObject.tag != "Scenery") {
            Destroy(gameObject);
        }
    }

}
