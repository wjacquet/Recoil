using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleAbility : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            PlayerAbilities playerAbility = GameObject.Find("obj_player").GetComponent<PlayerAbilities>(); 
            AbilitySelection abilitySelection = GameObject.Find("Pause-Map-Screens").GetComponent<AbilitySelection>(); 
            
            playerAbility.SetBubble(true);
            AbilitySelection.currentAbility = "bubble";
            abilitySelection.bubbleClicked();
            Destroy(gameObject);
        }
    }
}
