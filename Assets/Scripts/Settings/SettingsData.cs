using UnityEngine;

public class SettingsData : MonoBehaviour
{
    [SerializeField] private Settings _settings;

    public Settings Settings { get => _settings; }

    public static SettingsData instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if (this != instance)
        {
            Destroy(this);
        }
    }
}

