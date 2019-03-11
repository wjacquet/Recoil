using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class RoomTransition : MonoBehaviour
{
    public string warpScene;
    public Vector3 warpPosition;

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.name == "obj_player") {
            bool[] newUpgradeIndexes = new bool[SceneManager.sceneCountInBuildSettings];

            Array.Copy(PlayerInit.loadedUpgradesFound, newUpgradeIndexes, PlayerInit.loadedUpgradesFound.Length);

            if (PlayerHealth.sceneIDForUpgrade != -1) {
                newUpgradeIndexes[PlayerHealth.sceneIDForUpgrade] = true;
            }

            // Build current player metadata
            PlayerMetaData player = new PlayerMetaData(
                PlayerHealth.maxHP,
                PlayerHealth.currHP,
                PlayerCurrency.wealth,
                warpScene,
                new[] {warpPosition.x, warpPosition.y, warpPosition.z},
                newUpgradeIndexes,
                PlayerInit.scenesVisited,
                PlayerInit.gunsFound,
                PlayerInit.selectedGuns,
                PlayerInit.currentGunIndex
            );

            // Warp player to next scene
            PlayerInit.SetPlayer(player);
        }
    }
}
