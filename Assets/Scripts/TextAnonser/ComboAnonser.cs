using UnityEngine;
using UnityEngine.UI;

public class ComboAnonser : MonoBehaviour
{
    [SerializeField] private Text _text;

    [SerializeField] private string _preText;

    private void Start()
    {
        _text.text = _preText + PointData.instance.Score.Combo + "x";
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
