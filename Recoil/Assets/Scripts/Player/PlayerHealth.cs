using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int initialHP = 3;
    public int currHP = 3;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
