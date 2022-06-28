using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class PointView : MonoBehaviour
{
    [SerializeField] private Point _point;

    private Text _pointText;

    private void Awake()
    {
        _pointText = GetComponent<Text>();
        SetPointText(_point.Value);
    }

    void OnEnable()
    {
        _point.Changed += Points_Increased;
    }

    private void Points_Increased(int count)
    {
        SetPointText(count);
    }

    private void SetPointText(int point)
    {
        _pointText.text = point.ToString();
    }

    private void OnDisable()
    {
        _point.Changed -= Points_Increased;
    }
}
