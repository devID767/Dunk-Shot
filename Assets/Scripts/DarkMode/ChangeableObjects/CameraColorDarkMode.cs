using UnityEngine;

public class CameraColorDarkMode : ChangeableDarkMode
{
    [SerializeField] private Camera _camera;

    [SerializeField] private Color DarkMode;
    [SerializeField] private Color LightMode;

    public override void ActiveDarkMode()
    {
        _camera.backgroundColor = DarkMode;
    }

    public override void ActiveLightMode()
    {
        _camera.backgroundColor = LightMode;
    }
}