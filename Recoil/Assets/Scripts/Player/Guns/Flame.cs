using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
    private int damage = 1;

    // Once the projectile hits a wall
    // void OnCollisionEnter2D(Collision2D collision) 
    // {
    //     string tag = collision.gameObject.tag;
    //     if (collision.gameObject.tag == "Enemy") {
    //         collision.gameObject.GetComponent<EnemyHealth>().Damage(damage);
    //     }
    //     if (tag != "Player" && tag != "Gun" && tag != "Bullet") {
    //         Destroy(gameObject);
    //     }
    // }

    void OnTriggerEnter2D(Collider2D collision) 
    {
        print(collision.gameObject.tag);
        string tag = collision.gameObject.tag;
        if (collision.gameObject.tag == "Enemy") {
            collision.gameObject.GetComponent<EnemyHealth>().Damage(damage);
        }
    }

    void OnTriggerStay2D(Collider2D collision) 
    {
        print(collision.gameObject.tag);
        string tag = collision.gameObject.tag;
        if (collision.gameObject.tag == "Enemy") {
            collision.gameObject.GetComponent<EnemyHealth>().Damage(damage);
        }
    }

    public void SetDamage(int dam) {
        damage = dam;
    }
}
