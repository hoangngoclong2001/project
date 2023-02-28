using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public int level;
    public float health;
    public int score;
    public float[] position;
    public PlayerData()
    {
    }
}
public class DataManager : MonoBehaviour
{
    // Singleton
    public static DataManager instance;

    public PlayerData data = new PlayerData();

    public bool isSaveGame = false;
    public bool isLoadGame = false;
  
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void SavePlayer()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";
        FileStream fileStream = new FileStream(path, FileMode.Create);
        data.position = new float[3];
        formatter.Serialize(fileStream, data);
        fileStream.Close();
    }

    public void LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);

            data = formatter.Deserialize(fileStream) as PlayerData;
            fileStream.Close();
        }
        else
        {
            Debug.LogError("Save file not found in" + path);
        }
    }
}