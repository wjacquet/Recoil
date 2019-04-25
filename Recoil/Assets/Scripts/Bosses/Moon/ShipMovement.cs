using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{

    private bool moveLeft = false, moveRight = false, moveMid = false;
    public Vector3 left, right, mid; 

    private int baseMultiplier = 100;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moveLeft) 
        {
            transform.position = Vector2.MoveTowards(transform.position, left, baseMultiplier * Time.deltaTime);
        }
        if (moveRight) 
        {
            transform.position = Vector2.MoveTowards(transform.position, right, baseMultiplier * Time.deltaTime);
        }
        if (moveMid) 
        {
            transform.position = Vector2.MoveTowards(transform.position, mid, baseMultiplier * Time.deltaTime);
        }
    }

    public void TriggerLeftMovement() 
    {
        moveLeft = true;
    }

    public void TriggerRightMovement() 
    {
        moveRight = true;
    }

    public void TriggerMidMovement() 
    {
        moveMid = true;
    }

    public void ChangeMultiplier(int newMult) 
    {
        baseMultiplier = newMult;
    }

    public void StopMovement() 
    {
        moveLeft = false;
        moveRight = false; 
        moveMid = false;
    }

}
