using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

    public static bool gameIsPaused = false;

    public GameObject mapUI;


    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.M)) {
            if (gameIsPaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Resume() {
        mapUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause() {
        mapUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
}




















