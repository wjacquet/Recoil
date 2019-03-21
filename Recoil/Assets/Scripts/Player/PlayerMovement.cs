using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    protected Rigidbody2D rigidBody;
    public float speedLimit;
    public SpriteRenderer mySpriteRenderer;
    public GameObject gun;

    void Start() {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        rigidBody.freezeRotation = true;
    }
    
    void Update() {
        GameObject cursor = GameObject.Find("obj_cursor");


        // Check which direction to face sprite
        if (cursor.transform.position.x <= transform.position.x) 
            mySpriteRenderer.flipX = true;
        else
            mySpriteRenderer.flipX = false;
        
        // // Make gun direction match player direction
        // gun.GetComponent<PivotGun>().FlipGun(mySpriteRenderer.flipX);
    }

    public void Recoil(Vector2 knockback) {
        rigidBody.velocity = rigidBody.velocity + knockback;
        if (rigidBody.velocity.magnitude > speedLimit) {
            rigidBody.velocity = rigidBody.velocity.normalized * speedLimit;
        }
    }
}
