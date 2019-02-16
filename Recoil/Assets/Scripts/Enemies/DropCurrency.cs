using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCurrency : MonoBehaviour
{
    public GameObject coin;
    public int amount;
    GameObject player;

    void Start() 
    {
        player = GameObject.Find("obj_player");
    }

    // Update is called once per frame
    public void DropCoins()
    {
        for (int i = 0; i < amount; i++) {
            Instantiate(coin, transform.position, transform.rotation);
        }
    }
}
