using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private PlayerHealth playerHP;
    void Start() 
    {
        GameObject player = GameObject.Find("obj_player");
        playerHP = player.GetComponent<PlayerHealth>();
        StartCoroutine(Timer());
    }

    IEnumerator Timer() {
        yield return new WaitForSeconds(2.0f);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Player") {
            playerHP.TakeDamage();
        }
    }
}
