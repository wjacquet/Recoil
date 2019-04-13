using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    // public static bool SelectionMenus.gameIsPaused = false;

    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) {
            if (SelectionMenus.gameIsPaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }
    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        SelectionMenus.gameIsPaused = false;
    }

    void Pause() {
        Cursor.visible = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        SelectionMenus.gameIsPaused = true;
    }

    public void LoadMenu() {
        if (!SceneManager.GetActiveScene().name.Equals("StartingArea")) {
            DataControl.Save();
        }   
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame() {   
        if (!SceneManager.GetActiveScene().name.Equals("StartingArea")) {
            DataControl.Save();
        }   
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit(); 
        #endif
        Debug.Log("Exiting Game!");
    }
}




















