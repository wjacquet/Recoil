using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour {

    public GunSelection gunSelection;
    public SpriteRenderer m;

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            gunSelection.FlipStore(true);
            m.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            gunSelection.FlipStore(false);
            m.enabled = false;
        }
    }
}

