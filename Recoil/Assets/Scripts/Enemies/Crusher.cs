using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crusher : MonoBehaviour
{
    public int speed = 100;
    GameObject player;
    PlayerHealth playerHP;
    public Vector2 direction = Vector2.down;

    //private position startPos;

    // Start is called before the first frame update
    void Start()
    {
        //startPos = transform.position;
        GameObject player = GameObject.Find("obj_player");
        playerHP = player.GetComponent<PlayerHealth>();
        CrushMe();
    }

    void CrushMe() {
        Rigidbody2D rigidBody = gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;

        // Find player and find the direction vector
        GameObject player = GameObject.Find("obj_player");
        playerHP = player.GetComponent<PlayerHealth>();
        direction = Vector2.down;

        direction.Normalize();
        rigidBody.velocity += direction * speed;

    }

    IEnumerator PauseCrushing (float timeWaiting, Vector2 dir) 
    {
            yield return new WaitForSeconds(timeWaiting);
            setVel(dir);
    }

    void setVel(Vector2 dir) 
    {
        Rigidbody2D rigidBody = gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        direction = dir;
        direction.Normalize();
        rigidBody.velocity = direction * speed;
    }

    void flipDirection ()
    {
        Rigidbody2D rigidBody = gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        rigidBody.velocity = Vector2.zero;


        if (direction == Vector2.up)
        {
            StartCoroutine(PauseCrushing(2f, Vector2.down));
            //setVel(Vector2.down);
        } else
        {
            StartCoroutine(PauseCrushing(0.5f, Vector2.up));
        }
    }

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.tag == "Player") {
            playerHP.TakeDamage();
        }
        flipDirection();
    }
}
