using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    public GameObject player;
    PlayerHealth playerHP;
    // Start is called before the first frame update
    void Start()
    {
        // Find player
        playerHP = player.GetComponent<PlayerHealth>();
    }

    // Hurt the player on contact
    void OnCollisionEnter2D(Collision2D collision) 
    {
        print(collision);
        if (collision.gameObject.tag == "Player") {
            playerHP.TakeDamage();
        }
    }
}
