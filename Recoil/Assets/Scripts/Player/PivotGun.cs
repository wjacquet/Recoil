﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotGun : MonoBehaviour {

    public GameObject bullet;
    public GameObject player;

    private Vector3 offset;
    private Vector3 originalPosition;
    private Vector3 flippedPosition;
    private bool flipped = false;

    Transform gunSprite;


    private Vector3[] gunPlacementsNeg = new Vector3[6] {
                                                            new Vector3(-5.0f, 1f, 0f),
                                                            new Vector3(-6.0f, 1f, 0f),
                                                            new Vector3(-8.0f, 2f, 0f),
                                                            new Vector3(-8.0f, 0f, 0f),
                                                            new Vector3(-4.0f, 1f, 0f),
                                                            new Vector3(-8.0f, 1f, 0f),
                                                        };

    private Vector3[] gunPlacementsPos = new Vector3[6] {
                                                            new Vector3(5.0f, 1f, 0f),
                                                            new Vector3(6.0f, 1f, 0f),
                                                            new Vector3(8.0f, 2f, 0f),
                                                            new Vector3(8.0f, 0f, 0f),
                                                            new Vector3(4.0f, 1f, 0f),
                                                            new Vector3(8.0f, 1f, 0f),
                                                        };



    void Start() {
        player = GameObject.Find("obj_player");
        gunSprite = gameObject.transform.GetChild(PlayerInit.selectedGuns[PlayerInit.currentGunIndex]).transform;
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

    public void SetSprite(Transform sprite) {
        gunSprite = sprite;

    }

    public void FlipGun(bool flip) {
        flipped = flip;

        if (flipped) {
            gunSprite.localPosition = gunPlacementsNeg[PlayerInit.selectedGuns[PlayerInit.currentGunIndex]];
        } else {
            gunSprite.localPosition = gunPlacementsPos[PlayerInit.selectedGuns[PlayerInit.currentGunIndex]];
        }      

        // move gun to player's hand
        offset = flip ? flippedPosition : originalPosition;
    }
}


