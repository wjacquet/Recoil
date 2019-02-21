using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentryMovement : MonoBehaviour
{
    public float speed;
    public LayerMask enemyMask;
    private Rigidbody2D body;
    private Transform trans;
    private float width,height;
    // Start is called before the first frame update
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
        trans = this.transform;
        SpriteRenderer sprit = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
        width = trans.GetChild(0).GetComponent<SpriteRenderer>().bounds.extents.x;//this.GetComponent<SpriteRenderer>().bounds.extents.x;//sprit.bounds.extents.x;
        //height = sprit.bounds.extents.y;
    }


    // https://www.youtube.com/watch?v=LPNSh9mwT4w
    // This is the video I used to figure out ledge control, he also goes over turning around when you hit a wall but I can't get that to work yet

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 lineCastPos = trans.position - trans.right * width;
        Vector3 lineCastV3 = lineCastPos;
        Vector2 transRightV2 = trans.right;
        Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down * 10);
        bool isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down * 10, enemyMask);
        bool isBlocked = Physics2D.Linecast(lineCastPos, lineCastPos - transRightV2, enemyMask);
        Debug.DrawLine(lineCastPos, lineCastPos + transRightV2);

        if (!isGrounded || isBlocked) {
            //trans.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;
            Vector3 currRotation = trans.eulerAngles;
            currRotation.y += 180;
            trans.eulerAngles = currRotation;
        }

        Vector2 vel = body.velocity;
        vel.x = -trans.right.x * speed;
        body.velocity = vel;
    }
}
