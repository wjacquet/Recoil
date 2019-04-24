using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDamage : MonoBehaviour
{
    GameObject player;
    PlayerHealth playerHP;
    bool damagePlayer = true;
    private AbilitySelection abilitySelection;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("obj_player");
        playerHP = player.GetComponent<PlayerHealth>();
        abilitySelection = GameObject.Find("Pause-Map-Screens").GetComponent<AbilitySelection>();
    }

    void OnTriggerStay2D(Collider2D collision) 
    {
        // Hurt over time
        if (collision.gameObject.tag == "Player" && AbilitySelection.currentAbility != "bubble" && damagePlayer) {
            playerHP.TakeDamage();
            damagePlayer = false;
            StartCoroutine(WaitForDamage());
        }
    }

    IEnumerator WaitForDamage() {
        yield return new WaitForSeconds(2.0f);
        damagePlayer = true;
    }
}
