using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianOscilate : MonoBehaviour
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

    void FixedUpdate()
    {
        Vector2 lineCastPos = trans.position - trans.right * width;
        Vector3 lineCastV3 = lineCastPos;
        Vector2 transRightV2 = trans.right;

        bool isGrounded;
        
        Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down * 40);
        isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down * 40, enemyMask);
        //Debug.Log("IsGrounded: " + isGrounded);
        

        bool isBlocked = Physics2D.Linecast(lineCastPos, lineCastPos - transRightV2, enemyMask);
        //Debug.Log("IsBlocked: " + isBlocked);

        Debug.DrawLine(lineCastPos, lineCastPos + transRightV2);

        
        //Debug.Log("IsGround: " + isGrounded + "IsBlocked: " + isBlocked);

        if (!isGrounded || isBlocked)
        {
        //Debug.Log("IsGround: " + isGrounded + "IsBlocked: " + isBlocked);
        Vector3 currRotation = trans.eulerAngles;
        currRotation.y += 180;
        trans.eulerAngles = currRotation;
        }

        Vector2 vel = body.velocity;
        vel.x = -trans.right.x * speed;
        body.velocity = vel;
        Debug.Log(body.velocity);
        
    }
}
