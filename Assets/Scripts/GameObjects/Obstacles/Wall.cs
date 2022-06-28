using UnityEngine;

public class Wall : Obstacle
{
    [SerializeField] private Audio _audio;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Ball ball))
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
        _audio.Play(AudioManager.instance.Data.Wall.Clip, AudioManager.instance.Data.Wall.Volume);
    }
}
