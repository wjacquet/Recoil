using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour {

    private GameObject player; 
    private PlayerHealth playerHP;

    void Start() {           
        player = GameObject.Find("obj_player");
        playerHP = player.GetComponent<PlayerHealth>();

        StartCoroutine(CactusPattern());
    }

    IEnumerator CactusPattern() {
        while (true) {
            yield return Jump();
            yield return Stop();
            yield return Fall();
            yield return Stop();
        }
    }

    // // Update is called once per frame
    IEnumerator Jump() {
        StandardFireFunctions.FireVetically(gameObject);

        yield return new WaitForSeconds(0.8f);
    }

    IEnumerator Stop() {
        StandardFireFunctions.StopFire(gameObject);

        yield return new WaitForSeconds(0.8f);
    }

    IEnumerator Fall() {
        StandardFireFunctions.FireDown(gameObject);

        yield return new WaitForSeconds(0.8f);
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            playerHP.TakeDamage();   
        }
    }

}
