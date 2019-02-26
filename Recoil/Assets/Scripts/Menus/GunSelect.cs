using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GunSelect : MonoBehaviour {

    public static bool gameIsPaused = false;
    public GameObject gunSelectUI;

    public GameObject gunBox1;
    public GameObject gunBox2;
    public GameObject gunBox3;
    public GameObject gunBox4;
    public GameObject gunBox5;

    public string[] selectedGuns = new string[2];
    public int currentSelection = 0;

    void Update() {
        if (Input.GetKeyDown(KeyCode.G)) {
            if (gameIsPaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void gunPressed() {

        // Debug.Log(selectedGuns[0]);
        selectedGuns[currentSelection] = EventSystem.current.currentSelectedGameObject.name;

        Debug.Log(" ");
        Debug.Log(selectedGuns[0]);
        Debug.Log(selectedGuns[1]);
        Debug.Log(" ");

        if (currentSelection == 0) currentSelection = 1;
        else currentSelection = 0;

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
