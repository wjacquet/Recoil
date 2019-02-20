using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;


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
        player.maxHP = PlayerHealth.maxHP;
        player.currHP = PlayerHealth.currHP;
        player.wealth = PlayerCurrency.wealth;
        player.scene = SceneManager.GetActiveScene().name;//"Scenes/EnemyTest";
        player.position = FindCheckpointPos();//new[] { -136f, -64f, 0f };
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
}
