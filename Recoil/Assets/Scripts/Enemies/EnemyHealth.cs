using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int initialHP;
    private int currHP;
    DropCurrency dropCurr;
    
    void Start() {
        dropCurr = gameObject.GetComponent<DropCurrency>();
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
        dropCurr.DropCoins();
    }

    public int getCurrHP() {return currHP;}
}
