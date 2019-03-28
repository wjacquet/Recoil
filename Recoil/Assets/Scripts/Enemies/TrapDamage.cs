using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDamage : MonoBehaviour
{
    GameObject player;
    PlayerHealth playerHP;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("obj_player");
        playerHP = player.GetComponent<PlayerHealth>();
    }

    void OnTriggerEnter2D(Collider2D collision) 
    {
                // Hurt player on contact
        if (collision.gameObject.tag == "Player") {
            playerHP.TakeDamage();
        }
    }
}
