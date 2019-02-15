using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    protected Rigidbody2D rigidBody;
    void Start() {
        rigidBody = gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        rigidBody.freezeRotation = true;
    }
    public void Recoil(Vector2 knockback) {
        rigidBody.velocity = knockback;
    }
}
