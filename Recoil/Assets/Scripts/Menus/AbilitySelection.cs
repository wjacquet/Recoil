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
    public GameObject abilityBox3;
    public GameObject selection;
    public GameObject ability;

    public Image selectedImage;
    public Image selectedAbility;

    public Sprite magnetSprite;
    public Sprite flowerSprite;
    public Sprite speedSprite;
    public Sprite bubbleSprite;

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
        bool bubble = false;

        if (PlayerAbilities.magnet) magnet = true;
        if (PlayerAbilities.flower) flower = true;
        if (PlayerAbilities.speed) speed = true;
        if (PlayerAbilities.bubble) bubble = true;

        abilityBox0.SetActive(magnet);
        abilityBox1.SetActive(flower);
        abilityBox2.SetActive(speed);
        abilityBox3.SetActive(bubble);
    }

    void updateCurrentSelection() {
        if (currentAbility == "magnet") {
            selectedImage.sprite = magnetSprite;
            selectedAbility.sprite = magnetSprite;
            ResetPlayerSpeed(70);
        } else if (currentAbility == "flower") {
            selectedImage.sprite = flowerSprite;
            selectedAbility.sprite = flowerSprite;
            ResetPlayerSpeed(70);
        } else if (currentAbility == "speed") {
            selectedImage.sprite = speedSprite;
            selectedAbility.sprite = speedSprite;
        } else if (currentAbility == "bubble") {
            selectedImage.sprite = bubbleSprite;
            selectedAbility.sprite = bubbleSprite;
        } else {
            selection.SetActive(false);
            ability.SetActive(false);
            return;
        }

        selection.SetActive(true);
        ability.SetActive(true);
    }

    void ResetPlayerSpeed(int speed) {
        PlayerMovement playerMovement = GameObject.Find("obj_player").GetComponent<PlayerMovement>(); 
        playerMovement.speedLimit = speed;
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
        ResetPlayerSpeed(250);

        updateCurrentSelection();
    }

    public void bubbleClicked() {
        currentAbility = "bubble";
        abilityText.text = "Nick: Go to AbilitySelection.cs ~line 111 and say what it does";

        updateCurrentSelection();
    }

}
