﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballMovement : MonoBehaviour
{
    private PlayerHealth playerHP;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("obj_player");
        playerHP = player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        float yVal = (Mathf.Sin(transform.position.x / 10) * 2.5f) + transform.position.y;
        transform.position = new Vector3(transform.position.x + 1, yVal, transform.position.z);
    }

    // Fireball damages player
    void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.tag == "Player") {
            playerHP.TakeDamage();
        }
    }
}
