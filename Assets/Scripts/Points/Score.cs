using UnityEngine;

public class Score : Point
{
    [SerializeField] private Audio _audio;

    private int _combo = 0;

    public int Combo { get => _combo; }

    private bool _wasPerfectThrow;

    private void IncreaseCombo()
    {
        if(_combo < AudioManager.instance.Data.Score.Clips.Length - 1)
            _combo++;
    }

    public void StopCombo()
    {
        _wasPerfectThrow = false;
        _combo = 0;
    }

    public override void IncreaseOn(int value)
    {
        if (!_wasPerfectThrow)
        {
            _wasPerfectThrow = true;
        }
        else
        {
            IncreaseCombo();
        }

        base.IncreaseOn(value + _combo);
        Debug.Log("value: " + Value + "combo: " + _combo);

        PlaySound(_combo);
    }

    private void PlaySound(int combo)
    {
        AudioClip clip = AudioManager.instance.Data.Score.Clips[combo].Clip;
        float volume = AudioManager.instance.Data.Score.Clips[combo].Volume;

        _audio.Play(clip, volume);
    }
}
