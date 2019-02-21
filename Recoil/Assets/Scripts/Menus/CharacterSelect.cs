using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    public GameObject obj_player;
    // Update is called once per frame
    void changeSprite()
    {
        obj_player.player.GetComponent<SpriteRenderer>().sprite = null;
    }
}
