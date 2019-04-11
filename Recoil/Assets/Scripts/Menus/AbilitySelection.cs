using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class AbilitySelection : MonoBehaviour {

    public GameObject abilityBox0;
    public GameObject abilityBox1;
    public GameObject abilityBox2;
    public GameObject selection;
    public GameObject ability;

    public Image selectedImage;
    public Image selectedAbility;

    public Sprite magnetSprite;
    public Sprite flowerSprite;
    public Sprite speedSprite;

    public TextMeshProUGUI abilityText;

    public static string currentAbility = "";

    void Start() {
        selection.SetActive(false);
        updateCurrentSelection();
    }

    void Update() {
        if (SelectionMenus.abilitiesOpen) 
            if (SelectionMenus.gameIsPaused) 
                ShowAbilitesUnlocked();
    }

    void ShowAbilitesUnlocked() {
        bool magnet = false;
        bool flower = false;
        bool speed = false;

        if (PlayerAbilities.magnet) magnet = true;
        if (PlayerAbilities.flower) flower = true;
        if (PlayerAbilities.speed) speed = true;

        abilityBox0.SetActive(magnet);
        abilityBox1.SetActive(flower);
        abilityBox2.SetActive(speed);
    }

    void updateCurrentSelection() {
        if (currentAbility == "magnet") {
            selectedImage.sprite = magnetSprite;
            selectedAbility.sprite = magnetSprite;
            ResetPlayerSpeed();
        } else if (currentAbility == "flower") {
            selectedImage.sprite = flowerSprite;
            selectedAbility.sprite = flowerSprite;
            ResetPlayerSpeed();
        } else if (currentAbility == "speed") {
            selectedImage.sprite = speedSprite;
            selectedAbility.sprite = speedSprite;
        } else {
            selection.SetActive(false);
            ability.SetActive(false);
            return;
        }

        selection.SetActive(true);
        ability.SetActive(true);
    }

    void ResetPlayerSpeed() {
        PlayerMovement playerMovement = GameObject.Find("obj_player").GetComponent<PlayerMovement>(); 
        playerMovement.speedLimit = 70;
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

    public void speedClicked() {
        currentAbility = "speed";
        abilityText.text = "This ability raises the speed limit allowing you to have a faster maximum speed";

        updateCurrentSelection();
    }

}
