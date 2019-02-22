using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    public GameObject obj_player;
    public Button clickedButton;
    public SpriteRenderer rend;

    public static Sprite selectedSkin;

    public void Start()
    {
        GameObject player = GameObject.Find("player");
        rend = player.GetComponent<SpriteRenderer>();
        Sprite sprite = Resources.Load<Sprite>("Assets/Resources/spaceman-m.aseprite");
        selectedSkin = clickedButton.GetComponent<Image>().sprite;
        Debug.Log("defaulted sprite to " + selectedSkin);
    }

    public void changeSprite()
    {
        GameObject player = GameObject.Find("player");
        rend = player.GetComponent<SpriteRenderer>();

        //rend.sprite = clickedButton.GetComponent<Image>().sprite;
        selectedSkin = clickedButton.GetComponent<Image>().sprite;

        Debug.Log("switched sprite to " + selectedSkin.texture);
    }

}
