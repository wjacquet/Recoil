using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollection : MonoBehaviour
{
    public int value;
    PlayerCurrency playerCurr;

    void Start() 
    {
        GameObject player = GameObject.Find("obj_player");
        playerCurr = player.GetComponent<PlayerCurrency>();
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Player") {
            playerCurr.AddCurrency(value);
        }
        Destroy(gameObject);
    }
}
