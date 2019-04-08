using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class AbilitySelection : MonoBehaviour {

    public GameObject abilityBox0;
    public GameObject abilityBox1;
    public GameObject selection;

    public Image selectedImage;
    public Sprite magnetSprite;
    public Sprite flowerSprite;

    public TextMeshProUGUI abilityText;

    public static string currentAbility = "";

    void Start() {
        selection.SetActive(false);
    }

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

    void updateCurrentSelection() {
        if (currentAbility == "magnet")
            selectedImage.sprite = magnetSprite;
        else if (currentAbility == "flower")
            selectedImage.sprite = flowerSprite;

        selection.SetActive(true);
    }

    public void magnetClicked() {
        currentAbility = "magnet";
        abilityText.text = "This ability allows you to right click on a magnet block and it will then magnet towards you.";

        updateCurrentSelection();
    }

    public void flowerClicked() {
        currentAbility = "flower";
        abilityText.text = "This ability allows you to place a temporary magic block any where you left click.";

        updateCurrentSelection();
    }

}
