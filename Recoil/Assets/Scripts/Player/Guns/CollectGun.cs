using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectGun : MonoBehaviour
{
    public int gunIndex;
    GameObject player;

    void Start() 
    {
        player = GameObject.Find("obj_player");
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Player") {
            AddGun(gunIndex);
            Destroy(gameObject);
        }   
    }

    void AddGun(int gunID) 
    {
        PlayerInit.gunsFound[gunID] = true;
    }
}
