using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static int maxHP = 3;
    public static int currHP = 3;
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

        if (--currHP <= 0) {
            setHealthText(currHP);
            // Dead
            Die();
            return;
        }
        setHealthText(currHP);
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

    void Start()
    {
        setHealthText(currHP);
    }


    void setHealthText(int health)
    {
        healthText.text = "H P : " + health +" / " + initialHP;
        healthSlider.value = health;
    }

}
