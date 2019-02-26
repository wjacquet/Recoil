using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSelect : MonoBehaviour {

    public static bool gameIsPaused = false;
    public GameObject gunSelectUI;

    void Update() {
        if (Input.GetKeyDown(KeyCode.G)) {
            if (gameIsPaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }
    public void Resume() {
        gunSelectUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause() {
        Cursor.visible = true;
        gunSelectUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
}
