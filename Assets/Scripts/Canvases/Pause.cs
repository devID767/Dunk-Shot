using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] private Game _gameCanvas;

    private void OnEnable()
    {
        Time.timeScale = 0;
        GameStatus.Set(EGameStatus.Pause);
    }

    public void OnSettingsButtonClicked()
    {

    }

    public void OnMainMenuButtonClicked()
    {
        GameStatus.Set(EGameStatus.Menu);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnCustomizeButtonClicked()
    {

    }

    public void OnResumeButtonClicked()
    {
        _gameCanvas.gameObject.SetActive(true);
        GameStatus.Set(EGameStatus.IsPlaying);
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }
}
