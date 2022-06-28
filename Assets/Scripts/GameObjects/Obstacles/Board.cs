using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private Audio _audio;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Ball ball))
        {
            if (!ball.IsGhost)
            {
                PlaySound();
            }
        }
    }

    private void PlaySound()
    {
        _audio.Play(AudioManager.instance.Data.Border.Clip, AudioManager.instance.Data.Border.Volume);
    }
}
