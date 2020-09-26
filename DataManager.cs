using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using UnityEngine;

public class DataManager : MonoBehaviour
{

    public PlayerData data;

    private string file = "player.txt";
    public void Save()
    {
        string json = JsonUtility.ToJson(data);
        WriteToFile(file, json);
    }
    public void Load()
    {
        data = new PlayerData();
        string json = ReadFromFile(file);
        JsonUtility.FromJsonOverwrite(json, data);
    }
    private void WriteToFile(string filename, string json)
    {
        string path = GetFilePath(filename);
        FileStream fileStream = new FileStream(path, FileMode.Create);
        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(json);
        }
    }
    private string ReadFromFile(string filename)
    {
        string path = GetFilePath(filename);
        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();
                return json;
            }

        }
        else
            Debug.LogWarning("File not FOUND");
              return "";
    }
    private string GetFilePath(string filename)
    {
        return Application.persistentDataPath + "/" + filename;
    }
}
