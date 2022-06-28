using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Save
{
    private string _filePath;

    public string FilePath { get => _filePath; }

    public Save()
    {
        _filePath = Application.persistentDataPath + "data.gamesave";
    }

    public Save(string filePath)
    {
        _filePath = filePath;
    }

    public void SaveGame(Action<SavedData> saving)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(_filePath, FileMode.Create);

        SavedData data = new SavedData();

        saving.Invoke(data);

        bf.Serialize(fs, data);
        fs.Close();
    }

    public void LoadGame(Action<SavedData> loading)
    {
        if (!File.Exists(_filePath))
            return;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(_filePath, FileMode.Open);

        SavedData data = (SavedData)bf.Deserialize(fs);

        loading.Invoke(data);

        fs.Close();
    }
}
