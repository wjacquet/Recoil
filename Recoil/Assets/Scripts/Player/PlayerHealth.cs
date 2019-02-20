﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static int maxHP = 3;
    public static int currHP = 3;
    private int iFrames = 0;

    

    void Update() 
    {
        if (iFrames > 0) iFrames--;
    }

    public void TakeDamage() 
    {
        if (iFrames != 0) return;

        if (--currHP <= 0) {
            // Dead
            Die();
            return;
        }
        iFrames = 35;
    }

    public static void UpgradeHP() 
    {
        maxHP++;
        currHP++;
    }

    public static void Heal() 
    {
        currHP = maxHP;
    }

    void Die() 
    {
        DataControl.Respawn();
        //Destroy(gameObject);
    }

}
