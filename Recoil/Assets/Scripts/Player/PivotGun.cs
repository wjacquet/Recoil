using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotGun : MonoBehaviour {

    public GameObject bullet;
    public GameObject player;
    
    public GameObject gun; 
    private Vector3 offset;
    private Vector3 originalPosition;
    private Vector3 flippedPosition;
    private bool flipped = false;
    public SpriteRenderer mySpriteRenderer;

    Transform sprit;

    void Start() {
        sprit = gameObject.transform.GetChild(0).GetChild(0).transform;
        offset = transform.position - player.transform.position;
        originalPosition = offset;
        flippedPosition = new Vector3(offset.x - 10, offset.y, offset.z);
    }

    // Update is called once per frame
    void Update() {  

        // rotate gun
        GameObject cursor = GameObject.Find("obj_cursor");
        Vector2 direction = cursor.transform.position - transform.position;
        int aimLow = 1; // we need to negate the angle if the cursor is below the gun
        if (cursor.transform.position.y < transform.position.y) {
            aimLow = -1;
        }

        float angle = Vector2.Angle(Vector2.right, direction);

        // fix angle if sprite is flipped
        if (flipped) {
            angle = angle - 180f;
        }
        angle = angle * aimLow;

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void LateUpdate() {
        // Gun stays in player's hand
        transform.position = player.transform.position + offset;
    }

    public void FlipGun(bool flip) {
        mySpriteRenderer.flipX = flip;
        flipped = flip;

        if (flipped) {
            sprit.localPosition = new Vector3(-10f, 0f, 0f);
        } else {
            sprit.localPosition = new Vector3(0f, 0f, 0f);
        }      

        // move gun to player's hand
        offset = flip ? flippedPosition : originalPosition;
    }
}
