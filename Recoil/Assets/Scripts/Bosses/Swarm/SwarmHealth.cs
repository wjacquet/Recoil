using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmHealth : MonoBehaviour
{
    public int initialHP;
    private int currHP;
    
    void Start() {
        currHP = initialHP;
    }

    public void Damage(int amount) {
        amount = amount < 1 ? 1 : amount;
        currHP -= amount;
        if (currHP <= 0) {
            Death();
        }
    }

    void Death() {
        Destroy(gameObject);
    }
}
