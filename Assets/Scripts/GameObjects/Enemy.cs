using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameOver _gameOver;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Ball ball))
        {
            if (!ball.IsGhost)
            {
                ball.Die();
                _gameOver.gameObject.SetActive(true);
            }
        }
    }
}
