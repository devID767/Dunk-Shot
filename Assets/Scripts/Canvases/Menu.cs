using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private Game _gameCanvas;

    public void Start()
    {
        GameStatus.Set(EGameStatus.Menu);
    }

    public void StartGame()
    {
        if (GameStatus.Get() == EGameStatus.Menu)
        {
            GameStatus.Set(EGameStatus.IsPlaying);
            gameObject.SetActive(false);

            _gameCanvas.gameObject.SetActive(true);
        }
    }
}
