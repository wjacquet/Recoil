using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int initialHP;
    private int currHP;
    
    void Start() 
    {
        currHP = initialHP;
    }

    public void Damage() {
        if (--currHP <= 0) {
            Death();
        }
    }

    void Death() 
    {
        Destroy(gameObject);
    }
}
