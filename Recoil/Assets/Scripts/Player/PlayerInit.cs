using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PlayerInit : MonoBehaviour
{
    public static Vector3 playerPos;
    public static void SetPlayer(PlayerMetaData data) 
    {
        SceneManager.LoadScene(data.scene);
        playerPos = new Vector3(data.position[0], data.position[1], data.position[2]);
        SceneManager.sceneLoaded += OnSceneLoaded;
        PlayerHealth.maxHP = data.maxHP;
        PlayerHealth.currHP = data.currHP;
        PlayerCurrency.wealth = data.wealth;
    }

    static void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        GameObject playerModel = GameObject.Find("obj_player");
        playerModel.transform.position = playerPos;
    }
// TODO : This may need to be made asynchronous but depending on if triggering this function on every scene load becomes a problem or not
// if it does go back to trying to figure out LoadSceneAsycn and trying to set the player object on completion of that
}
