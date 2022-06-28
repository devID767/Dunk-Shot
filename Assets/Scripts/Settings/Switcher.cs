using UnityEngine;
using UnityEngine.UI;

public class Switcher: MonoBehaviour
{
    [SerializeField] private Image _image;

    [SerializeField] private Sprite _on;
    [SerializeField] private Sprite _off;

    public void Set(bool flag)
    {
        if (flag)
        {
            _image.sprite = _on;
        }
        else
        {
            _image.sprite = _off;
        }
    }
}
