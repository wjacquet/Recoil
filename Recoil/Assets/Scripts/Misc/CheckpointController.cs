using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour {

    public GunSelection gunSelection;

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            PlayerHealth playerHP = GameObject.Find("obj_player").GetComponent<PlayerHealth>();
            gunSelection.FlipCheckpoint(true);
            playerHP.Heal();
            DataControl.Save();
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            gunSelection.FlipCheckpoint(false);
            // playerHP.Heal();
            // DataControl.Save();
        }
    }
}

