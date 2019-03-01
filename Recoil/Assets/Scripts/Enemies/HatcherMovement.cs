using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatcherMovement : MonoBehaviour {
    
    public GameObject hatcher;
    GameObject player;
    PlayerHealth playerHP;
    
    // Start is called before the first frame update
    void Start() {
        GameObject player = GameObject.Find("obj_player");
        playerHP = player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update() {
        player = GameObject.Find("obj_player");
        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, playerPos, 75 * Time.deltaTime);    
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            playerHP.TakeDamage();
        } 
    }

}
