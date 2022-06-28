using System.Collections.Generic;
using UnityEngine;

public class ToSaveData : MonoBehaviour
{
    [Header("Data to save")]
    [SerializeField] private PointData _pointData;
    [SerializeField] private BackGroundColorMode _backGroundColorMode;
    [SerializeField] private Settings _settings;
    [SerializeField] private Customize _customize;

    public void SaveData(SavedData data)
    {
        data.SavePointData(_pointData);

        data.DarkMode = _backGroundColorMode.DarkMode;

        data.SoundOn = _settings.SoundSetting.Get();
        data.VibrationOn = _settings.VibrationSetting.Get();

        //if(_customize.Items != null)
            data.SaveSkins(_customize.Items);
    }

    public void LoadData(SavedData data)
    {
        _pointData.Record.Set(data.Record);
        _pointData.Coins.Set(data.Coins);

        _backGroundColorMode.Set(data.DarkMode);

        _settings.SoundSetting.Set(data.SoundOn);
        _settings.VibrationSetting.Set(data.VibrationOn);

        _customize.SetDataToSkins(data.BoughtSkins.ToArray(), data.SelectedSkin.ToArray());
    }
}

[System.Serializable]
public class SavedData
{
    public int Coins;
    public int Record;


    public void SavePointData(PointData pointData)
    {
        Record = pointData.Record.Value;
        Coins = pointData.Coins.Value;
    }

    public bool DarkMode;
    public bool SoundOn;
    public bool VibrationOn;

    public List<bool> BoughtSkins = new List<bool>();
    public List<bool> SelectedSkin = new List<bool>();

    public void SaveSkins(ItemCustomize[] items)
    {
        foreach (var item in items)
        {
            BoughtSkins.Add(item.Bought);
            SelectedSkin.Add(item.Selected);
        }
    }

    [System.Serializable]
    public struct Vect3
    {
        public float x, y, z;

        public Vect3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}
