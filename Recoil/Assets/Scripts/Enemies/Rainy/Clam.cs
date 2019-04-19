using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clam : MonoBehaviour {

    public GameObject bullet;
    public float timeInBetweenBursts = 0.5f;
    public float burstTime = 0.45;

    GameObject player;
    PlayerHealth playerHP;

    private float speed = 50.0f;
    
    void Start() {
        player = GameObject.Find("obj_player");
        playerHP = player.GetComponent<PlayerHealth>();
        
        StartCoroutine(ClamShootPattern());
    }

    IEnumerator ClamShootPattern() {
        while(true) {
            yield return Shoot(0, 60);
            yield return Shoot(0, 60);

            yield return new WaitForSeconds(timeInBetweenBursts);

            yield return Shoot(30, 60);
            yield return Shoot(30, 60);

            yield return new WaitForSeconds(timeInBetweenBursts);

        }
    }

    IEnumerator Shoot(int i, int offsets) {
        for (; i <= 360; i += offsets) {
            StandardFireFunctions.FireDegreeOffset(Instantiate(bullet, transform.position, transform.rotation), i);
        }

        yield return new WaitForSeconds(burstTime);
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Player") {
            playerHP.TakeDamage();   
        } 
    }
}
