﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;


// TODO : Make an EDITOR load so that save file loads when the editor starts playing, except don't load a different scene

public class PlayerInit : MonoBehaviour {

    public static Vector3 playerPos;
    public static bool[] loadedUpgradesFound = new bool[SceneManager.sceneCountInBuildSettings];
    public static bool[] scenesVisited = new bool[SceneManager.sceneCountInBuildSettings];
    public static bool[] gunsFound = new bool[10];
    public static int[] selectedGuns = new int[2];
    public static int currentGunIndex = 0;
    public static void SetPlayer(PlayerMetaData data) 
    {
        SceneManager.LoadScene(data.scene);
        loadedUpgradesFound = data.upgradesFound;
        scenesVisited = data.scenesVisited;
        gunsFound = data.gunsFound;
        selectedGuns = data.selectedGuns;
        currentGunIndex = data.currentGunIndex;
        playerPos = new Vector3(data.position[0], data.position[1], data.position[2]);
        SceneManager.sceneLoaded += OnSceneLoaded;
        PlayerHealth.maxHP = data.maxHP;
        PlayerHealth.currHP = data.currHP;
        PlayerCurrency.wealth = data.wealth;
        PlayerAbilities.magnet = data.magnet;
        PlayerAbilities.flower = data.flower;
        PlayerAbilities.speed = data.speed;
        AbilitySelection.currentAbility = data.currentAbility;
        PlayerHealth.numberOfHealthUpgrades = data.numberOfHealthUpgrades;
    }

    static void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        GameObject playerModel = GameObject.Find("obj_player");
        playerModel.transform.position = playerPos;
        Debug.Log(scene.buildIndex);
        scenesVisited[scene.buildIndex] = true;

        GameObject camera = GameObject.Find("Main Camera");
        camera.transform.position = playerPos;

        GameObject hpUpgrade = GameObject.Find("obj_health_upgrade");
        if (hpUpgrade && loadedUpgradesFound[scene.buildIndex]) {
            Destroy(hpUpgrade);
        }

        // Hide Magnet on Each Scene if they already have the ability
        GameObject magnetAbility = GameObject.Find("obj_magnet");
        if (PlayerAbilities.magnet) {
            Destroy(magnetAbility);
        }

        // Hide Flower on Each Scene if they already have the ability
        GameObject flowerAbility = GameObject.Find("obj_flower_power");
        if (PlayerAbilities.flower) {
            Destroy(flowerAbility);
        }

        GameObject speedAbility = GameObject.Find("obj_speed_upgrade");
        if (PlayerAbilities.speed) {
            Destroy(speedAbility);
        }

        CheckForGuns();

        if (PlayerAbilities.speed) {
            Debug.Log("SPEED");
            PlayerMovement playerMovement = GameObject.Find("obj_player").GetComponent<PlayerMovement>();             
            playerMovement.speedLimit = 250;
        } else {
            PlayerMovement playerMovement = GameObject.Find("obj_player").GetComponent<PlayerMovement>();             
            playerMovement.speedLimit = 80;
        }
    }

    static void CheckForGuns() 
    {
        for (int i = 1; i < PlayerInit.gunsFound.Length; i++) 
        {
            if (PlayerInit.gunsFound[i]) { //This gun should be deleted if true, it has been found
                GameObject gunPickup = GameObject.Find("obj_drop_gun" + i);
                if (gunPickup) {
                    Destroy(gunPickup);
                }
            } 
            
        }
    }
// TODO : This may need to be made asynchronous but depending on if triggering this function on every scene load becomes a problem or not
// if it does go back to trying to figure out LoadSceneAsycn and trying to set the player object on completion of that
}
