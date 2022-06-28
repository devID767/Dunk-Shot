using UnityEngine;
using UnityEngine.UI;

public class ScoreAnonser : MonoBehaviour
{
    [SerializeField] private Text _text;

    [SerializeField] private string _preText;

    private void Start()
    {
        _text.text = _preText + (int)(PointData.instance.Score.Combo + 1);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
