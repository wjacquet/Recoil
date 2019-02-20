using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public static int maxHP = 3;
    public static int currHP = 3;
    private int iFrames = 0;
    public static int sceneIDForUpgrade = -1;

    public Text healthText;
    public Slider healthSlider;

    void Start()
    {
        setHealthText(currHP);
    }   

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

    public void UpgradeHP() 
    {
        maxHP++;
        currHP++;
        setHealthText(currHP);
        sceneIDForUpgrade = SceneManager.GetActiveScene().buildIndex;
    }

    public void Heal() 
    {
        currHP = maxHP;
        setHealthText(currHP);
    }

    void Die() 
    {
        DataControl.Respawn();
        //Destroy(gameObject);
    }

    void setHealthText(int health)
    {
        healthText.text = "H P : " + health +" / " + maxHP;
        healthSlider.value = health;
    }

}
