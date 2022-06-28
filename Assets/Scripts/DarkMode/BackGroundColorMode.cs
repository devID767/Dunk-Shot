using UnityEngine;

public class BackGroundColorMode : MonoBehaviour
{
    [SerializeField] private ChangeableDarkMode[] _changeableObjects;

    public bool DarkMode { get; private set; }

    public void SwitchMode()
    {
        DarkMode = !DarkMode;

        SwitchAll();
    }

    public void Set(bool darkMode)
    {
        DarkMode = darkMode;

        SwitchAll();
    }

    private void SwitchAll()
    {

        foreach (var changeableObj in _changeableObjects)
        {
            if (DarkMode)
            {
                changeableObj.ActiveDarkMode();
            }
            else
            {
                changeableObj.ActiveLightMode();
            }
        }
    }
        
}
