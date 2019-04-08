using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class AbilitySelection : MonoBehaviour {

    public GameObject abilityBox0;
    public GameObject abilityBox1;

    public Image selectedImage;
    public Sprite magnetSprite;
    public Sprite flowerSprite;

    public static string currentAbility = "";

    void Update() {
        // if (SelectionMenus.abilitiesOpen) 
        //     if (SelectionMenus.gameIsPaused) 
                // ShowAbilitesUnlocked();
    }

    void ShowAbilitesUnlocked() {
        bool magnet = false;
        bool flower = false;

        if (PlayerAbilities.magnet) magnet = true;
        if (PlayerAbilities.flower) flower = true;

        abilityBox0.SetActive(magnet);
        abilityBox1.SetActive(flower);
    }

    void updateCurrentSelection() {
        if (currentAbility == "magnet")
            selectedImage.sprite = magnetSprite;
        else if (currentAbility == "flower")
            selectedImage.sprite = flowerSprite;
    }


    public void magnetClicked() {
        currentAbility = "magnet";

        updateCurrentSelection();
    }

    public void flowerClicked() {
        currentAbility = "flower";

        updateCurrentSelection();
    }
}
