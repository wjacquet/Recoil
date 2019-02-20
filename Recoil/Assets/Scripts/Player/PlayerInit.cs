﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInit : MonoBehaviour
{
    public static Vector3 playerPos;
    public static void SetPlayer(PlayerMetaData data) 
    {
        SceneManager.LoadScene(data.scene);
        GameObject playerModel = GameObject.Find("obj_player");
        playerPos = new Vector3(data.position[0], data.position[1], data.position[2]);
        playerModel.transform.position = playerPos;
        PlayerHealth.initialHP = data.maxHP;
        PlayerHealth.currHP = data.currHP;
        PlayerCurrency.wealth = data.wealth;
    }
}
