using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jellyfish : MonoBehaviour {

    public float electricTime = 2.0f;
    
    SpriteRenderer electricField;
    GameObject player;
    PlayerHealth playerHP;
    PolygonCollider2D jellyfishColider;
    CircleCollider2D electricCollider;

    private bool electric = false;

    void Start() {
        jellyfishColider = gameObject.GetComponent("PolygonCollider2D")as PolygonCollider2D;
        electricCollider = gameObject.GetComponent("CircleCollider2D")as CircleCollider2D;
        
        electricField =  gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>();

        player = GameObject.Find("obj_player");
        playerHP = player.GetComponent<PlayerHealth>();

        StartCoroutine(ElectricPattern());
    }

    IEnumerator ElectricPattern() {
        while (true) {
            yield return Shield();
        }
    }

    IEnumerator Shield() {
        electricCollider.enabled = electric;
        electricField.enabled = electric;
        electric = !electric;

        yield return new WaitForSeconds(electricTime);
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Player") {
            playerHP.TakeDamage();   
        }
    }

}
