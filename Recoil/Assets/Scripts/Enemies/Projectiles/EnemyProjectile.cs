using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    PlayerHealth playerHP;

    void Start()
    {
        GameObject player = GameObject.Find("obj_player");
        playerHP = player.GetComponent<PlayerHealth>();
    }

    // Once the projectile hits a wall
    void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.tag == "Player") {
            playerHP.TakeDamage();
        }
        if (collision.gameObject.tag != "Enemy" && collision.gameObject.tag != "Fan") {
            Destroy(gameObject);
        }
    }

}
