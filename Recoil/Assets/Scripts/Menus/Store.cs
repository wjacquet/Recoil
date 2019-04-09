using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

// TODO Allow them to buy 
    // Should subtract from their coins
    // Should add to health / show gun in gun selection

// TODO Only Show the guns not already bought
public class Store : MonoBehaviour {

    public GameObject player;
   
    // void Update() {
    //     if (SelectionMenus.storeOpen) 
    //         if (SelectionMenus.gameIsPaused) 
    //             showAvailableStoreItems();
    // }

    // void showAvailableStoreItems() {

    // }

    public void itemSelected() {
        string indexStr = EventSystem.current.currentSelectedGameObject.name;
        int index = int.Parse(indexStr);
   
        int price = int.Parse(EventSystem.current.currentSelectedGameObject.GetComponentInChildren<TextMeshProUGUI>().text);
        
        if ((PlayerCurrency.wealth - price) >= 0) {            
            PlayerCurrency playerCurrency = player.GetComponent<PlayerCurrency>();
            playerCurrency.UpdateCurrency(PlayerCurrency.wealth - price);
        }

    }

}
