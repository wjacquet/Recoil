using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x != 0) {
            transform.position = Vector2.MoveTowards(transform.position, Vector2.zero, 80 * Time.deltaTime);
            return;
        }
    }
}
