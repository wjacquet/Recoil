using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    public GameObject obj_player;
    public Button clickedButton;
    // Update is called once per frame
    public void changeSprite()
    {
        GameObject player = GameObject.Find("player");
        SpriteRenderer rend = player.GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        rend.sprite = clickedButton.GetComponent<Image>().sprite;
        Debug.Log("switched sprite to" + rend.sprite);
    }
}
