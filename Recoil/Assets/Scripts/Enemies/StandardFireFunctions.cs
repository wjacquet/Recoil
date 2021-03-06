﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardFireFunctions : MonoBehaviour
{
    private static int speed = 70;
    // Start is called before the first frame update
    public static void FireAtPlayer(GameObject projectile) 
    {
        Vector2 direction = GetVectorToPlayer(projectile);
        SetVelocity(direction, projectile);
    }

    public static void FireAtPlayerWithSetSpeed(GameObject projectile, float speed) {
        Vector2 direction = GetVectorToPlayer(projectile);
        SetVelocityWithSpeed(direction, projectile, speed);
    }

    public static void MagnetTowardsPlayer(GameObject projectile, float speed) {
        Vector2 direction = GetVectorToPlayer(projectile);

        Rigidbody2D rigidBody = projectile.GetComponent<Rigidbody2D>();
        direction.y = 0;
        rigidBody.velocity = direction * speed;
    }

    public static void FireHorizontallyAtPlayer(GameObject projectile) 
    {
        Vector2 direction = GetVectorToPlayer(projectile);
        direction.y = 0;
        SetVelocity(direction, projectile);
    }

    public static void FireVeticallyAtPlayer(GameObject projectile) 
    {
        Vector2 direction = GetVectorToPlayer(projectile);
        direction.x = 0;
        SetVelocity(direction, projectile);
    }

    public static void FireVetically(GameObject projectile) 
    {
        Vector2 direction = new Vector2(0, 180);
        direction.x = 0;
        SetVelocity(direction, projectile);
    } 

    public static void FireLeft(GameObject projectile, float speed) 
    {
        Vector2 direction = new Vector2(-180, 0);
        direction.y = 0;
        SetVelocityWithSpeed(direction, projectile, speed);
    } 

    public static void FireRight(GameObject projectile, float speed) 
    {
        Vector2 direction = new Vector2(180, 0);
        direction.y = 0;
        SetVelocityWithSpeed(direction, projectile, speed);
    } 

    public static void FireVerticallyFakeGravity(GameObject projectile, float speed) {

        Vector2 direction = new Vector2(0, 180);
        direction.x = 0;

        SetVelocityWithSpeed(direction, projectile, speed);
    }
    
    public static void FireDown(GameObject projectile) 
    {
        Vector2 direction = new Vector2(0, -180);
        direction.x = 0;
        SetVelocity(direction, projectile);
    } 

    public static void FireDownFakeGravity(GameObject projectile, float speed) {

        Vector2 direction = new Vector2(0, -180);
        direction.x = 0;

        SetVelocityWithSpeed(direction, projectile, speed);
    }


    public static void StopFire(GameObject projectile) 
    {
        Vector2 direction = new Vector2(0, 0);
        direction.x = 0;
        SetVelocity(direction, projectile);
    }   

    public static void FireVeticallyDegreeOffset(GameObject projectile, int angleOffset) 
    {
        Vector2 direction = new Vector2(0, 180);

        float angleToPlayer = Mathf.Atan2(direction.x, direction.y);
        angleToPlayer = Mathf.Rad2Deg * angleToPlayer;
        angleToPlayer += angleOffset;

        direction.x = Mathf.Sin(Mathf.Deg2Rad * angleToPlayer);
        direction.y = Mathf.Cos(Mathf.Deg2Rad * angleToPlayer);
        SetVelocity(direction, projectile);
    }

    public static void FireDownDegreeOffset(GameObject projectile, int angleOffset, float speed) 
    {
        Vector2 direction = new Vector2(0, -180);

        float angleToPlayer = Mathf.Atan2(direction.x, direction.y);
        angleToPlayer = Mathf.Rad2Deg * angleToPlayer;
        angleToPlayer += angleOffset;

        direction.x = Mathf.Sin(Mathf.Deg2Rad * angleToPlayer);
        direction.y = Mathf.Cos(Mathf.Deg2Rad * angleToPlayer);
        SetVelocityWithSpeed(direction, projectile, speed);
    }

    public static void FireDegreeOffsetFromPlayer(GameObject projectile, int angleOffset) 
    {
        Vector2 direction = GetVectorToPlayer(projectile);

        float angleToPlayer = Mathf.Atan2(direction.x, direction.y);
        angleToPlayer = Mathf.Rad2Deg * angleToPlayer;
        angleToPlayer += angleOffset;

        direction.x = Mathf.Sin(Mathf.Deg2Rad * angleToPlayer);
        direction.y = Mathf.Cos(Mathf.Deg2Rad * angleToPlayer);

        SetVelocity(direction, projectile);
    }
    public static void FireDegreeOffsetFromPlayerSpeed(GameObject projectile, int angleOffset, int speed) 
    {
        Vector2 direction = GetVectorToPlayer(projectile);

        float angleToPlayer = Mathf.Atan2(direction.x, direction.y);
        angleToPlayer = Mathf.Rad2Deg * angleToPlayer;
        angleToPlayer += angleOffset;

        direction.x = Mathf.Sin(Mathf.Deg2Rad * angleToPlayer);
        direction.y = Mathf.Cos(Mathf.Deg2Rad * angleToPlayer);

        SetVelocityWithSpeed(direction, projectile,speed);
    }

    public static void FireDegreeOffset(GameObject projectile, int angleOffset) 
    {
        Vector2 direction = new Vector2(90, 0);

        float angleToPlayer = Mathf.Atan2(direction.x, direction.y);
        angleToPlayer = Mathf.Rad2Deg * angleToPlayer;
        angleToPlayer += angleOffset;

        direction.x = Mathf.Sin(Mathf.Deg2Rad * angleToPlayer);
        direction.y = Mathf.Cos(Mathf.Deg2Rad * angleToPlayer);

        SetVelocity(direction, projectile);
    }

    public static void FireInCircle(GameObject projectile, float speed, float angle, float radius) {

        Vector2 direction = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * radius;

        SetVelocityWithSpeed(direction, projectile, speed);
    }

    static Vector2 GetVectorToPlayer(GameObject projectile) 
    {
        // Find player and find the direction vector
        GameObject player = GameObject.Find("obj_player");
        return player.transform.position - projectile.transform.position;
    }

    static void SetVelocity(Vector2 direction, GameObject projectile) 
    {
        Rigidbody2D rigidBody = projectile.GetComponent<Rigidbody2D>();
        direction.Normalize();
        rigidBody.velocity = direction * speed;
    }

    public static void SetVelocityWithSpeed(Vector2 direction, GameObject projectile, float mySpeed) {
        Rigidbody2D rigidBody = projectile.GetComponent<Rigidbody2D>();
        direction.Normalize();
        rigidBody.velocity = direction * mySpeed;
    }

    public static void FireClusterAtPlayer(GameObject projectile) 
    {
        Vector2 direction = GetVectorToPlayer(projectile);
        SetVelocity(direction, projectile);


        float spreadAngle = Random.Range(-15f, 15f);
        float speedModifier = Random.Range(0.65f, 1f);
        float rotateAngle = spreadAngle + (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
        direction = new Vector2(Mathf.Cos(rotateAngle * Mathf.Deg2Rad), Mathf.Sin(rotateAngle * Mathf.Deg2Rad));

        SetVelocityWithSpeed(direction, projectile, speed * speedModifier);
    }

    public static void FireClusterDown(GameObject projectile) 
    {
        Vector2 direction = new Vector2(0, -180);
        direction.x = 0;
        SetVelocity(direction, projectile);


        float spreadAngle = Random.Range(-12f, 12f);
        float speedModifier = Random.Range(0.65f, 1f);
        float rotateAngle = spreadAngle + (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
        direction = new Vector2(Mathf.Cos(rotateAngle * Mathf.Deg2Rad), Mathf.Sin(rotateAngle * Mathf.Deg2Rad));

        SetVelocityWithSpeed(direction, projectile, speed * speedModifier);
    }

}
