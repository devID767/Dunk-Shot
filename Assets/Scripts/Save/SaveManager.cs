using System;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [SerializeField] private bool ResetData;
    [SerializeField] private ToSaveData _toSaveData;

    private Save _save;

    public static SaveManager instance;

    public static event Action DataLoaded;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (this != instance)
        {
            Destroy(this);
        }

        _save = new Save();

        if (!ResetData)
            Load();

        Save();
    }

    public void Save() => _save.SaveGame(SaveData);
    public void Load() => _save.LoadGame(LoadData);

    private void SaveData(SavedData data)
    {
        _toSaveData.SaveData(data);
    }
    private void LoadData(SavedData data)
    {
        _toSaveData.LoadData(data);
    }

    private void OnDestroy()
    {
        Save();
    }
}
