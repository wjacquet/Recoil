using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int initialHP = 3;
    public int currHP = 3;

    public void TakeDamage() 
    {
        currHP--;
        if (currHP <= 0) {
            // Dead
            Die();
        }
    }

    public void UpgradeHP() 
    {
        initialHP++;
        currHP++;
    }

    void Die() 
    {
        Destroy(gameObject);
    }
}
