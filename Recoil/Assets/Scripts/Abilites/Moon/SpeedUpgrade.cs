using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpgrade : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            PlayerAbilities playerAbility = GameObject.Find("obj_player").GetComponent<PlayerAbilities>(); 
            PlayerMovement playerMovement = GameObject.Find("obj_player").GetComponent<PlayerMovement>(); 
            AbilitySelection abilitySelection = GameObject.Find("Pause-Map-Screens").GetComponent<AbilitySelection>(); 
            
            playerMovement.speedLimit = 250;

            playerAbility.SetSpeed(true);
            AbilitySelection.currentAbility = "speed";
            abilitySelection.speedClicked();
            Destroy(gameObject);
        }
    }
}
