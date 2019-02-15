using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollection : MonoBehaviour
{
    public int value;
    PlayerCurrency playerCurr;
    GameObject player;

    void Start() 
    {
        player = GameObject.Find("obj_player");
        playerCurr = player.GetComponent<PlayerCurrency>();
    }

    void Update() 
    {
        player = GameObject.Find("obj_player");
        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, playerPos, 50 * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Player") {
            playerCurr.AddCurrency(value);
        }
        //Destroy(gameObject);
    }
}
