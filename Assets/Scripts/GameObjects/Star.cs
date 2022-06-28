using UnityEngine;

public class Star : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Ball ball))
        {
            if (!ball.IsGhost)
            {
                PointData.instance.Coins.IncreaseOn(1);
                PlaySound();
                Die();
            }
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void PlaySound()
    {
        AudioManager.instance.Play(AudioManager.instance.Data.Coin.Clip, AudioManager.instance.Data.Coin.Volume);
    }
}
