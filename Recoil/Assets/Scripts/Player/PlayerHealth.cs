using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int initialHP = 3;
    public int currHP = 3;
    private int iFrames = 0;

    public Text healthText;
    public Slider healthSlider;

    void Update() 
    {
        if (iFrames > 0) iFrames--;
    }

    public void TakeDamage() 
    {
        if (iFrames != 0) return;

        print(currHP);
        if (--currHP <= 0) {
            setHealthText(currHP);
            // Dead
            Die();
            return;
        }
        setHealthText(currHP);
        iFrames = 35;
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

    void setHealthText(int health)
    {
        healthText.text = "H P : " + health +" / " + initialHP;
        healthSlider.value = health;
    }
}
