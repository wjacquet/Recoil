using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

// TODO Allow them to buy 
    // Should add to health 
public class Store : MonoBehaviour {

    public GameObject player;
    
    public GameObject box1;
    public GameObject box2;
    public GameObject box3;
    public GameObject box4;
    public GameObject box5;
    public GameObject box6;

    private GameObject[] gunBoxes;

    void Start() {
        gunBoxes = new GameObject[6] {null, box1, box2, box3, box4, box5};

    }

    void Update() {
        if (SelectionMenus.storeOpen) 
            if (SelectionMenus.gameIsPaused) 
                showAvailableStoreItems();
    }

    void showAvailableStoreItems() {
        for (int i = 1; i < gunBoxes.Length; i++) {
            if (PlayerInit.gunsFound[i]) {
                gunBoxes[i].SetActive(false);
            } else {
                gunBoxes[i].SetActive(true);
            }
        }
    }

    public void itemSelected() {
        string indexStr = EventSystem.current.currentSelectedGameObject.name;
        int index = int.Parse(indexStr);
   
        int price = int.Parse(EventSystem.current.currentSelectedGameObject.GetComponentInChildren<TextMeshProUGUI>().text);
        
        if ((PlayerCurrency.wealth - price) >= 0) { 
            // Buying a Gun           
            if (index != 6) {
                PlayerCurrency playerCurrency = player.GetComponent<PlayerCurrency>();
                playerCurrency.UpdateCurrency(PlayerCurrency.wealth - price);
                PlayerInit.gunsFound[index] = true;
            // Buying Health Upgrade
            } else {
                PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
                playerHealth.BuyHP();
            }
        }

    }

}
