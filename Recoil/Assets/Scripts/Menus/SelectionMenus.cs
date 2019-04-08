﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionMenus : MonoBehaviour {

    public static bool gameIsPaused = false;
    // public static bool menuOpen = false;

    public GameObject selectionUI;
    public GameObject gunSelectionUI;
    public GameObject mapUI;

    public static bool gunSelectionOpen = false;
    public static bool mapOpen = false;

    void Update() {
        if (Input.GetKeyDown(KeyCode.G)) {
            if (gameIsPaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void gunSelectionClicked() {
        if (GunSelection.onCheckpoint) {
            gunSelectionOpen = !gunSelectionOpen;
            gunSelectionUI.SetActive(gunSelectionOpen);
        }
    }

    public void mapClicked() {
        mapOpen = !mapOpen;
        mapUI.SetActive(mapOpen);
    }

    public void Resume() {
        selectionUI.SetActive(false);
        gunSelectionUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        // menuOpen = false;
    }

    void Pause() {
        Cursor.visible = true;
        selectionUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        // menuOpen = true;
    }
}
