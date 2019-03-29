using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianEyeShot : MonoBehaviour
{
    PlayerHealth playerHP;

    void Start()
    {
        GameObject player = GameObject.Find("obj_player");
        playerHP = player.GetComponent<PlayerHealth>();
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHP.TakeDamage();
            Destroy(gameObject);
        }
    }
}
