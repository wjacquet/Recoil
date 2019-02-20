using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

    public static bool gameIsPaused = false;

    public GameObject mapUI;

    public GameObject levelOne;
    public GameObject levelOneGold;

    public GameObject levelTwo;
    public GameObject levelTwoGold;

    public GameObject levelThree;
    public GameObject levelThreeGold;

    public GameObject levelFour;
    public GameObject levelFourGold;

    public GameObject levelFive;
    public GameObject levelFiveGold;

    public GameObject levelSix;
    public GameObject levelSixGold;


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
        // Set basic map scene to disapear and gold scene to appear
        setActiveScene(levelOne, levelOneGold);

        mapUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    void setActiveScene(GameObject level, GameObject levelGold) {
        level.SetActive(false);
        levelGold.SetActive(true);
    }
}
