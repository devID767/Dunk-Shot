using UnityEngine;

public class Hoop : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] _spites;
    [SerializeField] private Color _newColor;

    [Header("Audio")]
    [SerializeField] private Audio _audio;

    public void ChangeColor()
    {
        foreach (var sprite in _spites)
        {
            sprite.color = _newColor;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Ball ball))
        {
            if (!ball.IsGhost)
            {
                PointData.instance.Score.StopCombo();
                PlaySound();
            }
        }
    }

    private void PlaySound()
    {
        _audio.Play(AudioManager.instance.Data.basketAudio.Hoop.Clip, AudioManager.instance.Data.basketAudio.Hoop.Volume);
    }
}
