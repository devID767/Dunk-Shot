using UnityEngine;

public class Bouncy : Obstacle
{
    [SerializeField] private Audio _audio;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ball ball))
        {
            if (!ball.IsGhost)
            {
                PlayAudio();
            }
        }
    }

    public override void Destroy()
    {
        Destroy(gameObject);
    }

    private void PlayAudio()
    {
        _audio.Play(AudioManager.instance.Data.Bouncy.Clip, AudioManager.instance.Data.Bouncy.Volume);
    }
}
