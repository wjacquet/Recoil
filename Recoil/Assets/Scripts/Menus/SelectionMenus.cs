using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionMenus : MonoBehaviour {

    public static bool gameIsPaused = false;

    public GameObject selectionUI;
    public GameObject gunSelectionUI;
    public GameObject abilitesUI;
    public GameObject storeUI;
    public GameObject mapUI;
    
    public static bool gunSelectionOpen = false;
    public static bool abilitiesOpen = false;
    public static bool storeOpen = false;
    public static bool mapOpen = false;

    void Update() {
        if (Input.GetKeyDown(KeyCode.M)) {
            if (gameIsPaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void gunSelectionClicked() {
        // if (GunSelection.onCheckpoint) {
        //     removeAllUI();

            gunSelectionOpen = !gunSelectionOpen;
            gunSelectionUI.SetActive(gunSelectionOpen);
        // }
    }

    public void abilitiesClick() {
        if (GunSelection.onCheckpoint) {
            removeAllUI();

            abilitiesOpen = !abilitiesOpen;
            abilitesUI.SetActive(abilitiesOpen);
        }
    }

    public void storeClicked() {
        if (GunSelection.onCheckpoint) {
            removeAllUI();

            storeOpen = !storeOpen;
            storeUI.SetActive(storeOpen);
        }
    }
    
    public void mapClicked() {
        removeAllUI();

        mapOpen = !mapOpen;
        mapUI.SetActive(mapOpen);        
    }

    void removeAllUI() {
        gunSelectionOpen = false;
        gunSelectionUI.SetActive(gunSelectionOpen);

        abilitiesOpen = false;
        abilitesUI.SetActive(abilitiesOpen);

        storeOpen = false;
        storeUI.SetActive(storeOpen);
            
        mapOpen = false;
        mapUI.SetActive(mapOpen);
    }

    public void Resume() {
        Cursor.visible = false;
        selectionUI.SetActive(false);
        gunSelectionUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause() {
        removeAllUI();
        Cursor.visible = true;
        selectionUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
}
