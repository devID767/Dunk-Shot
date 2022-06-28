using UnityEngine;

public class NightModeSetting : MonoBehaviour, ISettingable
{
    [SerializeField] private Switcher _switcher;
    [SerializeField] private BackGroundColorMode _nightMode;

    private bool _nightModeOn;

    private void OnEnable()
    {
        _nightModeOn = _nightMode.DarkMode;

        Update();
    }

    public bool Get()
    {
        return _nightModeOn;
    }

    public void Set(bool flag)
    {
        _nightModeOn = flag;
        Update();
    }

    public void Switch()
    {
        _nightModeOn = !_nightModeOn;
        Update();
    }

    public void Update()
    {
        _nightMode.Set(_nightModeOn);

        _switcher.Set(_nightModeOn);
    }
}
