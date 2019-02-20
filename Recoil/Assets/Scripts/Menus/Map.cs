using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Map : MonoBehaviour {

    public static bool gameIsPaused = false;

    public GameObject mapUI;

    public GameObject StartingArea;
    public GameObject StartingAreaGold;

    public GameObject Tutorial2;
    public GameObject Tutorial2Gold;

    public GameObject Tutorial3;
    public GameObject Tutorial3Gold;

    public GameObject Tutorial4;
    public GameObject Tutorial4Gold;

    public GameObject Tutorial5;
    public GameObject Tutorial5Gold;

    public GameObject TutorialBoss;
    public GameObject TutorialBossGold;


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

    public void Pause() {
        // Set basic map scene to disapear and gold scene to appear
        SetActiveScene(SceneManager.GetActiveScene().name);

        mapUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void SetActiveScene(string level) {
        FindScene(level)[0].SetActive(false);
        FindScene(level)[1].SetActive(true);
    }

    public GameObject[] FindScene(string level) {

        if (level.Equals(StartingArea.name)) {
            return (new[] {StartingArea, StartingAreaGold});

        } else if (level.Equals(Tutorial2.name)) {
            return  (new[] {Tutorial2, Tutorial2Gold});

        } else if (level.Equals(Tutorial3.name)) {
            return  (new[] {Tutorial3, Tutorial3Gold});

        } else if (level.Equals(Tutorial4.name)) {
            return  (new[] {Tutorial4, Tutorial4Gold});

        } else if (level.Equals(Tutorial5.name)) {
            return  (new[] {Tutorial5, Tutorial5Gold});

        } else if (level.Equals(TutorialBoss.name)) {
            return  (new[] {TutorialBoss, TutorialBossGold});
        } else {
            return null;
        }
    }
}
