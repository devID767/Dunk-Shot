using UnityEngine;

public class Game : MonoBehaviour
{
    private void OnEnable()
    {
        GameStatus.Changed += GameStatus_Changed;
    }

    private void GameStatus_Changed(EGameStatus status)
    {
        if(status != EGameStatus.IsPlaying)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        GameStatus.Changed -= GameStatus_Changed;
    }
}
