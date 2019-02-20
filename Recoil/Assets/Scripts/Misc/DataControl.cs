using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class DataControl : MonoBehaviour
{
    const string saveFolder = "SaveddData";
    const string saveFile = "Save.dat";
    
    public static void Save() 
    {
        string folderPath = Path.Combine(Application.persistentDataPath, saveFolder);
        if (!Directory.Exists (folderPath))
            Directory.CreateDirectory (folderPath);            

        string dataPath = Path.Combine(folderPath, saveFile);   
        
        PlayerMetaData player = new PlayerMetaData();
        player.maxHP = 4;
        player.currHP = 2;
        player.wealth = 9999999;
        player.scene = "Scenes/EnemyTest";
        player.position = new[] { -136f, -64f, 0f };
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        using (FileStream fileStream = File.Open (dataPath, FileMode.OpenOrCreate))
        {
            binaryFormatter.Serialize (fileStream, player);
        }         
    }

    public static void Load() 
    {
        string folderPath = Path.Combine(Application.persistentDataPath, saveFolder);           
        string dataPath = Path.Combine(folderPath, saveFile);

        BinaryFormatter binaryFormatter = new BinaryFormatter();
        PlayerMetaData player = new PlayerMetaData();
        using (FileStream fileStream = File.Open (dataPath, FileMode.Open))
        {
            player = (PlayerMetaData)binaryFormatter.Deserialize (fileStream);
        }
        print(player.maxHP + " " + player.currHP + " " + player.wealth);
        PlayerInit.SetPlayer(player);
    }

    public static void Respawn() 
    {

    }
}
