using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentryMovement : MonoBehaviour
{
    public float speed;
    public LayerMask enemyMask;
    private Rigidbody2D rigidBody;
    private float width,height;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        SpriteRenderer sprit = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
        width = sprit.bounds.extents.x;
        //height = sprit.bounds.extents.y;
    }


    // https://www.youtube.com/watch?v=LPNSh9mwT4w
    // This is the video I used to figure out ledge control, he also goes over turning around when you hit a wall but I can't get that to work yet

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 vecUp = new Vector3(0,1,0);
        Vector2 lineCast = transform.position - transform.right * width; // + vecUp * height;
        Vector2 vecDown = new Vector2(0,-0.3f);
        bool turnAroundGround = !Physics2D.Linecast(lineCast, lineCast + vecDown, enemyMask);

        // Debug.DrawLine(lineCast, lineCast - new Vector2(transform.right.x, transform.right.y) * 0.02f);
        // bool turnAroundWall = !Physics2D.Linecast(lineCast, lineCast - new Vector2(transform.right.x, transform.right.y) * 0.02f, enemyMask);

        if (turnAroundGround) { //|| turnAroundWall) {
            Vector3 currRotation = transform.eulerAngles;
            currRotation.y += 180;
            transform.eulerAngles = currRotation;
        }

        Vector2 sentryVel = rigidBody.velocity;
        sentryVel.x = transform.right.x * speed;
        rigidBody.velocity = sentryVel;
    }
}
