using UnityEngine;

public class PointData : MonoBehaviour
{
    public Score Score;
    public Record Record;
    public Coins Coins;

    public static PointData instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (this != instance)
        {
            Destroy(this);
        }
    }

    public void SaveRecord()
    {
        if(Score.Value > Record.Value)
        {
            Record.Set(Score.Value);
        }
    }
}
