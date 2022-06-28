using UnityEngine;

public class BasketGenerator : MonoBehaviour
{
    [SerializeField] private Basket[] _baskets;

    [SerializeField] private Basket _currentBasket;
    [SerializeField] private Basket _nextBasket;

    [SerializeField] private float _rightBoardX;
    [SerializeField] private float _leftBoardX;
    [SerializeField] private float _bottomBoardY;
    [SerializeField] private float _topBoardY;
    [SerializeField] private float _spaceBetweenBaskets;

    [Header("Audio")]
    [SerializeField] private Audio _audio;

    private void Start()
    {
        _currentBasket.Used = true;
    }

    private void OnEnable()
    {
        _nextBasket.CatchedBall += NextBasket_CatchedBall;
    }

    private void NextBasket_CatchedBall()
    {
        _nextBasket.CatchedBall -= NextBasket_CatchedBall;

        PointData.instance.Score.IncreaseOn(1);

        DestroyCurrentBusket();

        SpawnNewBasket();

        _nextBasket.CatchedBall += NextBasket_CatchedBall;
    }

    private void DestroyCurrentBusket()
    {
        _currentBasket.Destroy();
        _currentBasket = _nextBasket;
    }

    public void SpawnNewBasket()
    {
        var basket = GetBasket();

        _nextBasket = Instantiate(basket, basket.transform.position, basket.transform.rotation);

        _nextBasket.transform.position = GetNextBasketPosition();
        SetNextBasketPositionType();
        PlaySound();
    }

    private void PlaySound()
    {
        _audio.Play(AudioManager.instance.Data.basketAudio.Spawn.Clip, AudioManager.instance.Data.basketAudio.Spawn.Volume);
    }

    private Vector2 GetNextBasketPosition()
    {
        Vector2 pos = Vector2.zero;

        if (_nextBasket.EBasketPosition == EBasketPosition.Default)
        {
            pos = LookAtCurrentBasketPosition(pos);
        }
        else
        {
            pos = LookAtNextBasketPosition(pos);
        }

        pos.x += _nextBasket.transform.position.x;
        pos.y = _currentBasket.transform.position.y + Random.Range(_bottomBoardY, _topBoardY);

        return pos;
    }

    private Vector2 LookAtCurrentBasketPosition(Vector2 pos)
    {
        switch (_currentBasket.EBasketPosition)
        {
            case EBasketPosition.Left:
                pos.x = PositionInLeft();
                break;

            case EBasketPosition.Right:
                pos.x = PositionInRight();
                break;

            case EBasketPosition.Midle:
                if(Random.Range(0, 101) < 50)
                    pos.x = PositionInLeft();
                else
                    pos.x = PositionInRight();
                break;
        }

        return pos;
    }

    private Vector2 LookAtNextBasketPosition(Vector2 pos)
    {
        switch (_nextBasket.EBasketPosition)
        {
            case EBasketPosition.Left:
                pos.x = PositionInRight();
                break;

            case EBasketPosition.Right:
                pos.x = PositionInLeft();
                break;

            case EBasketPosition.Midle:
                pos.x = PositionInMidle();
                break;
        }

        return pos;
    }

    private float PositionInLeft()
    {
        return Random.Range(_currentBasket.transform.position.x + _spaceBetweenBaskets, _rightBoardX);
    }

    private float PositionInRight()
    {
        return Random.Range(_leftBoardX, _currentBasket.transform.position.x - _spaceBetweenBaskets);
    }

    private float PositionInMidle()
    {
        return 0;
    }

    private void SetNextBasketPositionType()
    {
        float distanceLeft = Mathf.Abs(_nextBasket.transform.position.x - _leftBoardX);
        float distanceRight = Mathf.Abs(_nextBasket.transform.position.x - _rightBoardX);
        float distanceMidle = Mathf.Abs(_nextBasket.transform.position.x - (_rightBoardX + _leftBoardX));

        if (distanceLeft < distanceRight)
        {
            if(distanceLeft < distanceMidle)
            {
                _nextBasket.EBasketPosition = EBasketPosition.Left;
            }
            else
            {
                _nextBasket.EBasketPosition = EBasketPosition.Midle;
            }
        }
        else
        {
            if(distanceRight < distanceMidle)
            {
                _nextBasket.EBasketPosition = EBasketPosition.Right;
            }
            else
            {
                _nextBasket.EBasketPosition = EBasketPosition.Midle;
            }
        }
    }

    private Basket GetBasket()
    {
        Basket basket = null;

        for (int i = 0; i < _baskets.Length; i++)
        {
            basket = _baskets[Random.Range(0, _baskets.Length)];

            if (_currentBasket.EBasketPosition != basket.EBasketPosition || (basket.EBasketPosition == EBasketPosition.Default))
            {
                break;
            }
        }

        return basket;
    }
}
