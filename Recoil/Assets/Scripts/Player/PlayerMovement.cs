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
        rigidBody = gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        rigidBody.freezeRotation = true;
    }

    void Update() {
        GameObject cursor = GameObject.Find("obj_cursor");

        if (Input.GetKeyDown(KeyCode.S)) {
            Debug.Log("switch!");
            // gun = GameObject.Find("obj_bolt_gun");
            gun = this.gameObject.transform.GetChild(4).gameObject;
            gun.SetActive(false);
            gun = this.gameObject.transform.GetChild(5).gameObject;
            gun.SetActive(true);
            // gun = GameObject.Find();
        }

        // Check which direction to face sprite
        if (cursor.transform.position.x <= transform.position.x) 
            mySpriteRenderer.flipX = true;
        else
            mySpriteRenderer.flipX = false;
        
        // Make gun direction match player direction
        gun.GetComponent<FireWeapon>().FlipGun(mySpriteRenderer.flipX);
    }

    public void Recoil(Vector2 knockback) {
        rigidBody.velocity = rigidBody.velocity + knockback;
        if (rigidBody.velocity.magnitude > speedLimit) {
            rigidBody.velocity = rigidBody.velocity.normalized * speedLimit;
        }
    }
}
