using UnityEngine;

public class Basket : MonoBehaviour
{
    [SerializeField] private BasketRotation _basketRotation;
    [SerializeField] private Hoop _hoop;
    [SerializeField] private Net _net;
    [SerializeField] private Obstacle[] _obstacles;

    [Header("Text anonsers")]
    [SerializeField] private TextAnonser _textAnonser;

    [Space]
    public EBasketPosition EBasketPosition;

    public bool Used { get; set; }


    public event System.Action CatchedBall;

    private void OnEnable()
    {
        _net.CatchBall += CatchBall;
        _net.ThrowBall += ThrowBall;
    }

    private void CatchBall(Ball ball)
    {
        ball.AssignToBasket(transform);

        _hoop.ChangeColor();
        _basketRotation.On();
        DestroyObstacles();
        SpawnTextAnonser();

        CatchedBall?.Invoke();
    }

    private void SpawnTextAnonser()
    {
        if(!Used)
        {
            Instantiate(_textAnonser, transform.position, Quaternion.identity);
            Used = true;
        }
    }

    private void DestroyObstacles()
    {
        foreach (var obstacle in _obstacles)
        {
            if(obstacle)
                obstacle.Destroy();
        }
    }

    private void ThrowBall(Ball ball)
    {
        _basketRotation.Off();
    }

    private void OnDisable()
    {
        _net.CatchBall -= CatchBall;
        _net.ThrowBall -= ThrowBall;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
