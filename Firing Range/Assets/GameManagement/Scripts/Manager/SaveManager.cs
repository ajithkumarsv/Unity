using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.Playables;

public class SaveManager : Singleton<SaveManager>
{
    private string savePath;

    public string levelLocation;

    private void Awake()
    {
        //_instance = this;
        savePath = Path.Combine(Application.persistentDataPath, "save.dat");
        levelLocation = Path.Combine( Application.dataPath, "Data");
        
    }

    public void Save(GameData data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream stream = new FileStream(savePath, FileMode.Create))
        {
            formatter.Serialize(stream, data);
        }
    }

    public void SaveLevel(LevelData data)
    {
        levelLocation = Path.Combine( Application.dataPath, "Data");
        string path = Path.Combine(levelLocation, $"level{data.level}.lvl");
        Debug.Log(path);
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
        {
            formatter.Serialize(stream, data);
        }
    }

    public LevelData LoadLevel(int level)
    {
        levelLocation = Path.Combine(Application.dataPath, "Data");
        string temppath = Path.Combine(levelLocation, $"level{level}.lvl");
        if (File.Exists(temppath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(temppath, FileMode.Open))
            {
                return formatter.Deserialize(stream) as LevelData;
            }
        }
        else
        {
            Debug.LogWarning("Save file not found.");
            return null;
        }
    }

   

    public GameData Load()
    {
        if (File.Exists(savePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(savePath, FileMode.Open))
            {
                return formatter.Deserialize(stream) as GameData;
            }
        }
        else
        {
            Debug.LogWarning("Save file not found.");
            return null;
        }
    }


    public SettingsData LoadSettings( )
    {
        string path = Application.persistentDataPath + "/settings.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SettingsData settingsData = JsonUtility.FromJson<SettingsData>(json);
            return settingsData;
        }
        else
        {
            SettingsData settingsData = new SettingsData { volume = 1,quality =0,isFullScreen =true }; // Default settings
            SaveSettings(settingsData);
            return settingsData;
        }
    }

    public void SaveSettings(SettingsData settingsData)
    {
        string json = JsonUtility.ToJson(settingsData);
        string path = Application.persistentDataPath + "/settings.json";
        File.WriteAllText(path, json);
    }
}
