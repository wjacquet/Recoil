using System.Collections;
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

    public static void FireDown(GameObject projectile) 
    {
        Vector2 direction = new Vector2(0, -180);
        direction.x = 0;
        SetVelocity(direction, projectile);
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
}
