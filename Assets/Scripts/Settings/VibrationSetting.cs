using UnityEngine;

public class VibrationSetting : MonoBehaviour, ISettingable
{
    [SerializeField] private Switcher _switcher;

    private bool _vibrationOn;

    private void OnEnable()
    {
        Update();
    }

    public bool Get()
    {
        return _vibrationOn;
    }

    public void Set(bool flag)
    {
        _vibrationOn = flag;
        Update();
    }

    public void Switch()
    {
        _vibrationOn = !_vibrationOn;

        if (_vibrationOn)
            Handheld.Vibrate();

        Update();
    }

    public void Update()
    {
        _switcher.Set(_vibrationOn);
    }
}