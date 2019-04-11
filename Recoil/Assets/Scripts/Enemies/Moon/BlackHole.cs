using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour {

    GameObject player;

    void Start() {
        player = GameObject.Find("obj_player");
    }


    void Update() {
        
        // player = GameObject.Find("obj_player");
        Vector2 magPos = new Vector2(transform.position.x, transform.position.y);

        if (Vector2.Distance(player.transform.position, magPos) < 50) {
            player.transform.position = Vector2.MoveTowards(player.transform.position, magPos, 50 * Time.deltaTime);
        }

    }
}
