using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkin : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("player");
        SpriteRenderer rend = player.GetComponent<SpriteRenderer>();
        
        if (CharacterSelect.selectedSkin != null) {
            Sprite theSkin = CharacterSelect.selectedSkin;
            rend.sprite = theSkin;
            player.transform.localScale = new Vector3(100, 100, 1);
            Debug.Log("vectored up " + theSkin);
        }
    }

    void Update()
    {
        Start();
        enabled = false;
    }
}
