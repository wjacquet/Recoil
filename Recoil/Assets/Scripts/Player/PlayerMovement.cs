using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    protected Rigidbody2D rigidBody;
    public float speedLimit;
    public SpriteRenderer mySpriteRenderer;
    public GameObject gun;

    int[] selectedGuns = new int[] {4, 5};
    int currentGunIndex = 0;

    void Start() {
        rigidBody = gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        rigidBody.freezeRotation = true;
    }
    
    void SwitchIndex() {
        if (currentGunIndex == 0)
            currentGunIndex = 1;
        else 
            currentGunIndex = 0;
    }

    void Update() {
        GameObject cursor = GameObject.Find("obj_cursor");

        if (Input.GetKeyDown(KeyCode.S)) {

            // gun = GameObject.Find("obj_bolt_gun");
            gun = this.gameObject.transform.GetChild(selectedGuns[currentGunIndex]).gameObject;
            gun.SetActive(false);
            SwitchIndex();
            gun = this.gameObject.transform.GetChild(selectedGuns[currentGunIndex]).gameObject;
            gun.SetActive(true);

            
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
