using UnityEngine;

public class TextAnonser : MonoBehaviour
{
    [SerializeField] private Animator _anim;

    [SerializeField] private ComboAnonser _comboAnonser;
    [SerializeField] private ScoreAnonser _scoreAnonser;

    private void Start()
    {
        if(PointData.instance.Score.Combo == 0)
        {
            InitScoreAnonser();
        }
        else
        {
            InitComboAnonser();
        }
    }

    private void InitComboAnonser()
    {
        _anim.SetTrigger("combo");
    }

    private void InitScoreAnonser()
    {
        _anim.SetTrigger("score");
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}

