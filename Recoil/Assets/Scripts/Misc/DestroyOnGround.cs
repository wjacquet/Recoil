using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnGround : MonoBehaviour
{
    // Once the object hits a wall
    void OnTriggerEnter2D(Collider2D collision) 
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Ground") {
            Destroy(gameObject);
        }
    }
}
