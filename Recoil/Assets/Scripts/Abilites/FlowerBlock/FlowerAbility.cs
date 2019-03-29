using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerAbility : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            PlayerAbilities playerAbility = GameObject.Find("obj_player").GetComponent<PlayerAbilities>(); 
            playerAbility.SetFlower(true);
            Destroy(gameObject);
        }
    }
}
