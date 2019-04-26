using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmElectricity : MonoBehaviour
{
    PlayerHealth playerHP;
    bool hurt = false;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("obj_player");
        playerHP = player.GetComponent<PlayerHealth>();
        StartCoroutine(Attack());
    }

    IEnumerator Attack() {
        gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 1.0f);
        yield return new WaitForSeconds(1.0f);
        hurt = true;
        gameObject.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }

    void OnTriggerStay2D(Collider2D collision) {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Player" && hurt) {
            playerHP.TakeDamage();   
        } 
    }
}
