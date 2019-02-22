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

        // Fix z ordering
        transform.position = new Vector3(transform.position.x, transform.position.y, -14);
    }

    IEnumerator Timer() {
        yield return new WaitForSeconds(2.0f);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.tag == "Player") {
            playerHP.TakeDamage();
        }
    }
}
