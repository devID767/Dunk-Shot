using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private void OnEnable()
    {
        PointData.instance.SaveRecord();
        GameStatus.Set(EGameStatus.GameOver);

        PlaySound();
    }

    public void Restart()
    {
        SaveManager.instance.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameStatus.Set(EGameStatus.Menu);
    }

    private void PlaySound()
    {
        AudioManager.instance.Play(AudioManager.instance.Data.Gameover.Clip, AudioManager.instance.Data.Gameover.Volume);
    }
}
