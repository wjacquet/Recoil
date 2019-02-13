using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int initialHP = 3;
    public int currHP = 3;
    private int iFrames = 0;

    void Update() 
    {
        if (iFrames > 0) iFrames--;
    }

    public void TakeDamage() 
    {
        if (iFrames != 0) return;
        currHP--;
        if (currHP <= 0) {
            // Dead
            Die();
        }
        iFrames = 20;
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
