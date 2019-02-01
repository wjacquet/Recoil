using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rigidBody = gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;

        GameObject cursor = GameObject.Find("obj_cursor");
        Vector2 direction = cursor.transform.position - transform.position;
        rigidBody.velocity = direction.normalized;
    }
}
