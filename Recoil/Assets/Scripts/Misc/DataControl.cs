using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class DataControl : MonoBehaviour
{
    const string saveFolder = "SavedData";
    const string saveFile = "Save.dat";
    
    public static void Save() 
    {          
        string dataPath = BuildPath();   
        bool[] newUpgradeIndexes = new bool[SceneManager.sceneCountInBuildSettings];

        Array.Copy(PlayerInit.loadedUpgradesFound, newUpgradeIndexes, PlayerInit.loadedUpgradesFound.Length);
        //print(string.Join(", ", newUpgradeIndexes));

        if (PlayerHealth.sceneIDForUpgrade != -1) {
            newUpgradeIndexes[PlayerHealth.sceneIDForUpgrade] = true;
        }

        PlayerMetaData player = new PlayerMetaData(
                        PlayerHealth.maxHP,
                        PlayerCurrency.wealth,
                        SceneManager.GetActiveScene().name,
                        FindCheckpointPos(),
                        newUpgradeIndexes
        );

        BinaryFormatter binaryFormatter = new BinaryFormatter();
        using (FileStream fileStream = File.Open (dataPath, FileMode.OpenOrCreate))
        {
            binaryFormatter.Serialize (fileStream, player);
        }         
    }

    public static void Load() 
    {
        string dataPath = BuildPath();

        BinaryFormatter binaryFormatter = new BinaryFormatter();
        PlayerMetaData player;// = new PlayerMetaData();
        using (FileStream fileStream = File.Open (dataPath, FileMode.Open))
        {
            player = (PlayerMetaData)binaryFormatter.Deserialize (fileStream);
        }
        PlayerInit.SetPlayer(player);
    }

    public static void Respawn() 
    {
        // For now respawn will just work the same way as Loading untill we polish it by adding a death screen / menu
        Load();
    }

    public static float[] FindCheckpointPos() 
    {
        GameObject checkpoint = GameObject.Find("obj_checkpoint");
        return new[] {checkpoint.transform.position.x, checkpoint.transform.position.y, checkpoint.transform.position.z};
    }

    public static void NewGame() 
    {
        string dataPath = BuildPath();   
        
        PlayerMetaData player = new PlayerMetaData(
                                    0,
                                    0,
                                    "Scenes/StartingArea",
                                    new[] { 9.6f, -4.1f, 0f },
                                    new bool[SceneManager.sceneCountInBuildSettings]);

        
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        using (FileStream fileStream = File.Open (dataPath, FileMode.OpenOrCreate))
        {
            binaryFormatter.Serialize (fileStream, player);
        }  
    }

    public static string BuildPath() 
    {
        string folderPath = Path.Combine(Application.persistentDataPath, saveFolder);
        if (!Directory.Exists (folderPath))
            Directory.CreateDirectory (folderPath);            

        return Path.Combine(folderPath, saveFile);   
    }
}
