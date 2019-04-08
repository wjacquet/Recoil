using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySelection : MonoBehaviour {

    public GameObject abilityBox0;
    public GameObject abilityBox1;

    void Update() {

        if (SelectionMenus.abilitiesOpen) 
            if (SelectionMenus.gameIsPaused) 
                ShowAbilitesUnlocked();
    }

    void ShowAbilitesUnlocked() {
        bool magnet = false;
        bool flower = false;

        if (PlayerAbilities.magnet) magnet = true;
        if (PlayerAbilities.flower) flower = true;

        abilityBox0.SetActive(magnet);
        abilityBox1.SetActive(flower);
    }
}
