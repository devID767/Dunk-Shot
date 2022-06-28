using UnityEngine;

public class Net : MonoBehaviour
{
    [SerializeField] private Transform _ballTransform;

    [Header("Audio")]
    [SerializeField]  private Audio _audio;

    private Ball _ball;

    public event System.Action<Ball> CatchBall;
    public event System.Action<Ball> ThrowBall;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ball ball))
        {
            if (!ball.IsGhost && ball.transform.parent != transform)
            {
                AssignBall(ball);
                CatchBall?.Invoke(ball);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ball ball))
        {
            if (ball & !ball.IsGhost)
            {
                UnsignBall(ball);
                ThrowBall?.Invoke(ball);
            }
        }
    }
    private void AssignBall(Ball ball)
    {
        _ball = ball;
        _ball.transform.position = _ballTransform.position;

        PlaySound();

        InputData.Active();
    }

    private void PlaySound()
    {
        _audio.Play(AudioManager.instance.Data.basketAudio.Net.Clip, AudioManager.instance.Data.basketAudio.Net.Volume);
    }

    private void UnsignBall(Ball ball)
    {
        ball.transform.parent = null;
        _ball = null;

        InputData.Deactive();
    }
}
