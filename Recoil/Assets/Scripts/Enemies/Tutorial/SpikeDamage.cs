﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    GameObject player;
    PlayerHealth playerHP;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("obj_player");
        playerHP = player.GetComponent<PlayerHealth>();
    }

    // Hurt the player on contact
    void OnCollisionEnter2D(Collision2D collision) 
    {
        // Hurt player on contact
        if (collision.gameObject.tag == "Player") {
            playerHP.TakeDamage();
        }
    }
}
