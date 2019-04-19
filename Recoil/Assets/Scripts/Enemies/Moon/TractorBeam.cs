using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorBeam : MonoBehaviour
{
    GameObject player;
    Rigidbody2D playerBody;
    Transform playerTrans;

    bool allowMove = false;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("obj_player");
        playerTrans = player.transform;
        playerBody = player.GetComponent<Rigidbody2D>();
    }

    void Update() 
    {
        if (allowMove)
            playerTrans.position = Vector2.MoveTowards(playerTrans.position, transform.position, 100 * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.tag == "Player") 
        {
            allowMove = true;
            //allowMove = false;
        }
    }

}
