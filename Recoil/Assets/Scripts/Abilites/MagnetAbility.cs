using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetAbility : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            PlayerHealth playerHP = GameObject.Find("obj_player").GetComponent<PlayerHealth>(); 
            // playerHP.UpgradeHP();
            Destroy(gameObject);
        }
    }
}
