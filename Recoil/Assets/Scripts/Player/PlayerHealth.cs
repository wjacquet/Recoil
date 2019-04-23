using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public static int maxHP = 10;
    public static int currHP = 10;
    private int iFrames = 0;
    public static int sceneIDForUpgrade = -1;
    public static int numberOfHealthUpgrades = 0;
    public int maxHealthBuys = 3;

    public Text healthText;
    public Slider healthSlider;
    private AbilitySelection abilitySelection;
    private BubbleController bubbleController;
    private bool hasBubbleInvincibilty = true;

    void Start()
    {
        setHealthText(currHP);
        abilitySelection = GameObject.Find("Pause-Map-Screens").GetComponent<AbilitySelection>();
        bubbleController = GameObject.Find("obj_player").GetComponent<BubbleController>(); 
    }   

    void Update() 
    {
        if (iFrames > 0) iFrames--;
    }

    public void TakeDamage() 
    {
        if (iFrames != 0) return;

        // Bubble invincibility
        if (AbilitySelection.currentAbility == "bubble" && hasBubbleInvincibilty) {
            StartCoroutine(BubbleRecharge());
            return;
        }

        if (--currHP <= 0) {
            setHealthText(currHP);
            // Dead
            Die();
            return;
        }
        setHealthText(currHP);
        iFrames = 60;
    }

    IEnumerator BubbleRecharge() {
        hasBubbleInvincibilty = false;
        bubbleController.EnableBubble(false);

        yield return new WaitForSeconds(5.0f);
        
        hasBubbleInvincibilty = true;
        bubbleController.EnableBubble(true);
    }

    public void UpgradeHP() 
    {
        maxHP++;
        currHP++;
        setHealthText(currHP);
        sceneIDForUpgrade = SceneManager.GetActiveScene().buildIndex;
    }

    public void BuyHP() {
        if ((numberOfHealthUpgrades++) < maxHealthBuys) {
            maxHP++;
            currHP++;
            setHealthText(currHP);
        }
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
        healthSlider.maxValue = maxHP;
        healthSlider.value = health;
    }

}
