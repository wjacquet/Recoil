using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetAbility : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            PlayerAbilities playerAbility = GameObject.Find("obj_player").GetComponent<PlayerAbilities>(); 
            AbilitySelection abilitySelection = GameObject.Find("Pause-Map-Screens").GetComponent<AbilitySelection>(); 
            
            playerAbility.SetMagnet(true);
            AbilitySelection.currentAbility = "magnet";
            abilitySelection.magnetClicked();
            Destroy(gameObject);
        }
    }
}
