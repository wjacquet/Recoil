using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{

    private bool moveLeft = false, moveRight = false, moveMid = false, pausedLeft, pausedRight, pausedMid;
    public Vector3 left, right, mid; 

    private int baseMultiplier = 60;

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
        moveMid = false;
        moveRight = false;
    }

    public void TriggerRightMovement() 
    {
        moveRight = true;
        moveLeft = false;
        moveMid = false;
    }

    public void TriggerMidMovement() 
    {
        moveMid = true;
        moveLeft = false;
        moveRight = false;
    }

    public void ChangeMultiplier(int newMult) 
    {
        baseMultiplier = newMult;
    }

    public Vector3 GetLeft() 
    {    
        return left;
    }

    public Vector3 GetRight() 
    {    
        return right;
    }

    public Vector3 GetMid() 
    {    
        return mid;
    }

    public void PauseMovement() 
    {
        pausedLeft = moveLeft;
        pausedRight = moveRight;
        pausedMid = moveMid;
        
        moveLeft = false;
        moveRight = false; 
        moveMid = false;
    }
    
    public void ResumeMovement() 
    {
        moveLeft = pausedLeft;
        moveRight = pausedRight;
        moveMid = pausedMid;
    }

    public bool isStationary() 
    {
        return (transform.position == left || transform.position == mid || transform.position == right); 
    }
}
