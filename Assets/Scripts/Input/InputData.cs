using System;
using UnityEngine;

public class InputData : MonoBehaviour
{
    public static event Action Touched;
    public static event Action Drag;
    public static event Action TouchCanceled;

    public static Vector2 StartPoint { get; private set; }
    public static Vector2 EndPoint { get; private set; }


    private static bool _on = true;
    public static bool On { get => _on; }

    private void Update()
    {
        if (GameStatus.Get() == EGameStatus.IsPlaying && On)
        {
            MouseInput();
            TouchInput();
        }
    }

    public static void Active()
    {
        Reset();
        _on = true;
    }

    public static void Deactive()
    {
        _on = false;
        Reset();
    }

    public static void Reset()
    {
        StartPoint = Vector2.zero;
        EndPoint = Vector2.zero;
    }

    private void TouchInput()
    {
        if (Input.touchCount > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                PointerDown(Camera.main.ScreenToWorldPoint(Input.touches[0].position));
            }

            if (Input.touches[0].phase == TouchPhase.Moved)
            {
                OnDrag(Camera.main.ScreenToWorldPoint(Input.touches[0].position));
            }

            if (Input.touches[0].phase == TouchPhase.Canceled)
            {
                PointerOn();
            }
        }
    }

    private void MouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PointerDown(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }

        if (Input.GetMouseButton(0))
        {
            OnDrag(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }

        if (Input.GetMouseButtonUp(0))
        {
            PointerOn();
        }
    }

    private void PointerDown(Vector2 pos)
    {
        StartPoint = pos;

        Touched?.Invoke();
    }

    private void OnDrag(Vector2 pos)
    {
        if (StartPoint == Vector2.zero)
            return;

        EndPoint = pos;
        Drag?.Invoke();
    }

    private void PointerOn()
    {
        TouchCanceled?.Invoke();
    }
}
