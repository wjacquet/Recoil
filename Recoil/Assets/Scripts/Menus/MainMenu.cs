using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public void PlayeGame() {
        SceneManager.LoadScene("Scenes/Starting Area");
    }

    public void LoadGame() 
    {
        DataControl.Load();
    }

    public void EndGame() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit(); 
        #endif
        Debug.Log("Exiting Game!");
    }
}
