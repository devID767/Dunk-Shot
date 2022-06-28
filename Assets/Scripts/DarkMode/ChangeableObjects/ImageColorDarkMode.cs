using UnityEngine;
using UnityEngine.UI;

public class ImageColorDarkMode : ChangeableDarkMode
{
    [SerializeField] private Image _image;

    [SerializeField] private Color DarkMode;
    [SerializeField] private Color LightMode;

    public override void ActiveDarkMode()
    {
        _image.color = DarkMode;
    }

    public override void ActiveLightMode()
    {
        _image.color = LightMode;
    }
}
