using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    private int mineHP = 1;

    // Update is called once per frame
    void Update()
    {
        
    }

    // If the mine comes into contact with anything else
    void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Enemy") {
            collision.gameObject.GetComponent<EnemyHealth>().Damage();
        }

        Destroy(gameObject);
    }
}
