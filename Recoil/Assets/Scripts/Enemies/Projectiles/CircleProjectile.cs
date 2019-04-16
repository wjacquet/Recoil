using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleProjectile : MonoBehaviour {

    PlayerHealth playerHP;

    public float speed = 5.0f;

    void Start() {
        GameObject player = GameObject.Find("obj_player");
        playerHP = player.GetComponent<PlayerHealth>();
    }

    void Fire() {
        StartCoroutine(CirclePattern());
    }

    IEnumerator CirclePattern() {
        while (true) {
            yield return Shoot();
        }
    }

    IEnumerator Shoot() {
        StandardFireFunctions.FireVerticallyFakeGravity(gameObject, speed);
        speed = speed + 1.0f;
        yield return new WaitForSeconds(0.01f);
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
