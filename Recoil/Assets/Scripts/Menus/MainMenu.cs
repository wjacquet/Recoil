﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public void PlayeGame() {
        SceneManager.LoadScene("Scenes/Starting Area");
    }

    public void EndGame() {
        Debug.Log("Exiting Game!");
        Application.Quit();
    }
}
