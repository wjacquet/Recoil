using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrchinMovement : MonoBehaviour {

    GameObject player;
    PlayerHealth playerHP;

    public Rigidbody2D rigidBody;
    public int fractionSpeed = 25;
    public float timeBetween = 1.0f;

    private Vector2 center;

    void Start() {
        player = GameObject.Find("obj_player");
        playerHP = player.GetComponent<PlayerHealth>();

        center = transform.position;
        // StartCoroutine(HoverPattern());
        rigidBody = gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
    }

    IEnumerator HoverPattern() {
        while (true) {
            yield return Hover(180);
            yield return Hover(-180);
        }
    }

    IEnumerator Hover(int yValue) {
        Vector2 movement = new Vector2(0, yValue);
        rigidBody.velocity = movement * 1/fractionSpeed;

        yield return new WaitForSeconds(timeBetween);
    }
     
    void OnTriggerEnter2D(Collider2D collision) {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Player") {
            playerHP.TakeDamage();   
        } 
    }

}
