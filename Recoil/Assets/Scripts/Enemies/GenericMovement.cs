using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericMovement : MonoBehaviour
{
    public float speed;
    public LayerMask enemyMask;
    private Rigidbody2D body;
    private Transform trans;
    private float width;

    public bool floor = true;
    public bool cieling = false;
    public bool right = false;
    public bool left = false;

    // Start is called before the first frame update
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
        trans = this.transform;
        SpriteRenderer sprit = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
        width = trans.GetChild(0).GetComponent<SpriteRenderer>().bounds.extents.x;
    }

    void FixedUpdate() {
        Vector2 lineCastPos = trans.position - trans.right * width;
        Vector3 lineCastV3 = lineCastPos;
        Vector2 transRightV2 = trans.right;
        
        bool isGrounded;
        if (right) {
            Debug.DrawLine(lineCastPos, lineCastPos + Vector2.right * 10);
            isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.right * 10, enemyMask);
        } else if (left) {
             Debug.DrawLine(lineCastPos, lineCastPos + Vector2.left * 10);
            isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.left * 10, enemyMask);
        } else if (cieling) {
            Debug.DrawLine(lineCastPos, lineCastPos + Vector2.up * 10);
            isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.up * 10, enemyMask);
        } else {
            Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down * 10);
            isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down * 10, enemyMask);
        } 

        bool isBlocked = Physics2D.Linecast(lineCastPos, lineCastPos - transRightV2, enemyMask);
        Debug.DrawLine(lineCastPos, lineCastPos + transRightV2);

        if (right || left) {
            if (!isGrounded || isBlocked) {
                Vector3 currRotation = trans.eulerAngles;
                currRotation.x += 180;
                trans.eulerAngles = currRotation;
            }

            Vector2 vel = body.velocity;
            vel.y = -trans.right.y * speed;
            body.velocity = vel;
        } else {
            if (!isGrounded || isBlocked) {
                Vector3 currRotation = trans.eulerAngles;
                currRotation.y += 180;
                trans.eulerAngles = currRotation;
            }

            Vector2 vel = body.velocity;
            vel.x = -trans.right.x * speed;
            body.velocity = vel;
        }
    }

    // void WalkOnRLeftWall() {
    //     Vector2 lineCastPos = trans.position - trans.right * width;
    //     Vector3 lineCastV3 = lineCastPos;
    //     Vector2 transRightV2 = trans.right;
        
    //     Debug.DrawLine(lineCastPos, lineCastPos + Vector2.right * 10);
    //     bool isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.left * 10, enemyMask);
    //     bool isBlocked = Physics2D.Linecast(lineCastPos, lineCastPos - transRightV2, enemyMask);
    //     Debug.DrawLine(lineCastPos, lineCastPos + transRightV2);

    //     if (!isGrounded || isBlocked) {
    //         Vector3 currRotation = trans.eulerAngles;
    //         currRotation.x += 180;
    //         trans.eulerAngles = currRotation;
    //     }

    //     Vector2 vel = body.velocity;
    //     vel.y = -trans.right.y * speed;
    //     body.velocity = vel;
    // }

    // void WalkOnRightWall() {
    //     Vector2 lineCastPos = trans.position - trans.right * width;
    //     Vector3 lineCastV3 = lineCastPos;
    //     Vector2 transRightV2 = trans.right;
        
    //     Debug.DrawLine(lineCastPos, lineCastPos + Vector2.right * 10);
    //     bool isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.right * 10, enemyMask);
    //     bool isBlocked = Physics2D.Linecast(lineCastPos, lineCastPos - transRightV2, enemyMask);
    //     Debug.DrawLine(lineCastPos, lineCastPos + transRightV2);

    //     if (!isGrounded || isBlocked) {
    //         Vector3 currRotation = trans.eulerAngles;
    //         currRotation.x += 180;
    //         trans.eulerAngles = currRotation;
    //     }

    //     Vector2 vel = body.velocity;
    //     vel.y = -trans.right.y * speed;
    //     body.velocity = vel;
    // }

    // void WalkOnFloor() {
    //     Vector2 lineCastPos = trans.position - trans.right * width;
    //     Vector3 lineCastV3 = lineCastPos;
    //     Vector2 transRightV2 = trans.right;
        
    //     Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down * 10);
    //     bool isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down * 10, enemyMask);
    //     bool isBlocked = Physics2D.Linecast(lineCastPos, lineCastPos - transRightV2, enemyMask);
    //     Debug.DrawLine(lineCastPos, lineCastPos + transRightV2);

    //     if (!isGrounded || isBlocked) {
    //         Vector3 currRotation = trans.eulerAngles;
    //         currRotation.y += 180;
    //         trans.eulerAngles = currRotation;
    //     }

    //     Vector2 vel = body.velocity;
    //     vel.x = -trans.right.x * speed;
    //     body.velocity = vel;
    // }

    // void WalkOnCieling() {
    //     Vector2 lineCastPos = trans.position - trans.right * width;
    //     Vector3 lineCastV3 = lineCastPos;
    //     Vector2 transRightV2 = trans.right;
        
    //     Debug.DrawLine(lineCastPos, lineCastPos + Vector2.up * 10);
    //     bool isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.up * 10, enemyMask);
    //     bool isBlocked = Physics2D.Linecast(lineCastPos, lineCastPos - transRightV2, enemyMask);
    //     Debug.DrawLine(lineCastPos, lineCastPos + transRightV2);

    //     if (!isGrounded || isBlocked) {
    //         Vector3 currRotation = trans.eulerAngles;
    //         currRotation.y += 180;
    //         trans.eulerAngles = currRotation;
    //     }

    //     Vector2 vel = body.velocity;
    //     vel.x = -trans.right.x * speed;
    //     body.velocity = vel;
    // }
}
