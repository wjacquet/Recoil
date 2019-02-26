using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunSelect : MonoBehaviour {

    public static bool gameIsPaused = false;
    public GameObject gunSelectUI;

    public GameObject gunBox1;
    public GameObject gunBox2;
    public GameObject gunBox3;
    public GameObject gunBox4;
    public GameObject gunBox5;

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
