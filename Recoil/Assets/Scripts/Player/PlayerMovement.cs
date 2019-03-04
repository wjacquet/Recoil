using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    protected Rigidbody2D rigidBody;
    public float speedLimit;
    public SpriteRenderer mySpriteRenderer;
    public GameObject gun;

    // Indexs of which guns they have selected
    // Will load this from save file
    // int[] selectedGuns = new int[] {0, 1};
    // Index of current gun holding from array above
    // Will load this from save file
    // int currentGunIndex = 0;

    void Start() {
        rigidBody = gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        rigidBody.freezeRotation = true;
    }
    
    // Switch between 0 and 1
    void SwitchIndex() {
        if (PlayerInit.currentGunIndex == 0)
            PlayerInit.currentGunIndex = 1;
        else 
            PlayerInit.currentGunIndex = 0;
    }

    void Update() {
        GameObject cursor = GameObject.Find("obj_cursor");

        // If user pushes S
        if (Input.GetKeyDown(KeyCode.S)) {
            SwitchGuns();
        }

        // Check which direction to face sprite
        if (cursor.transform.position.x <= transform.position.x) 
            mySpriteRenderer.flipX = true;
        else
            mySpriteRenderer.flipX = false;
        
        // Make gun direction match player direction
        gun.GetComponent<FireWeapon>().FlipGun(mySpriteRenderer.flipX);
    }

    void SwitchGuns() {
        // gun = GameObject.Find("obj_bolt_gun");
            
        // Hide Current Gun 
        gun = this.gameObject.transform.GetChild(PlayerInit.selectedGuns[PlayerInit.currentGunIndex]).gameObject;
        gun.SetActive(false);

        // Switch to new index
        SwitchIndex();
        
        // Show new gun
        gun = this.gameObject.transform.GetChild(PlayerInit.selectedGuns[PlayerInit.currentGunIndex]).gameObject;
        gun.SetActive(true);
    }

    public void Recoil(Vector2 knockback) {
        rigidBody.velocity = rigidBody.velocity + knockback;
        if (rigidBody.velocity.magnitude > speedLimit) {
            rigidBody.velocity = rigidBody.velocity.normalized * speedLimit;
        }
    }
}
