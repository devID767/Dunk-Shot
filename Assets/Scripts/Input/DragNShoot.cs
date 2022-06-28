using UnityEngine;

public class DragNShoot : MonoBehaviour
{
    [SerializeField] private float _power;
    [SerializeField] private float _maxRange;

    [SerializeField] private Trajectory _trajectory;

    [SerializeField] private Ball _ball;

    [Header("Dots transparent range")]
    [SerializeField] private float _minDistance;
    [SerializeField] private float _maxDistance;

    [Header("Release range")]
    [SerializeField] private float _minRelease;
    [SerializeField] private float _midRelease;

    [Header("Audio")]
    [SerializeField] private Audio _audio;

    private float _range;

    private void OnEnable()
    {
        InputData.Touched += _input_Touched;
        InputData.Drag += _input_Drag;
        InputData.TouchCanceled += _input_TouchCanceled;
    }

    private void _input_Touched()
    {
        _trajectory.Show();
    }

    private void _input_Drag()
    {
        Debug.DrawLine(InputData.StartPoint, InputData.EndPoint);

        _range = GetForce().magnitude;

        SetTransparentToDots();

        _trajectory.Simulate(_ball.transform.position, GetForce() * _power);
    }

    private void SetTransparentToDots()
    {
        if (_range < _minDistance)
        {
            _trajectory.SetTransparentToDots(0);
        }
        else if(_range < _maxDistance)
        {
            float a = (_range-_minDistance) / (_maxDistance-_minDistance);

            _trajectory.SetTransparentToDots(a);
        }
        else
        {
            _trajectory.SetTransparentToDots(1);
        }
    }

    private void _input_TouchCanceled()
    {
        Shoot();
        _trajectory.Hide();
    }

    private void Shoot()
    {
        if(_ball && _range > _minDistance)
        {
            _ball.Push(GetForce() * _power);
            PlaySound();
        }
    }

    private void PlaySound()
    {
        AudioClip clip;

        if (_range <= _minRelease)
        {
            clip = AudioManager.instance.Data.ReleaseBall.Low.Clip;
        }
        else if (_range <= _midRelease)
        {
            clip = AudioManager.instance.Data.ReleaseBall.Mid.Clip;
        }
        else
        {
            clip = AudioManager.instance.Data.ReleaseBall.High.Clip;
        }

        _audio.Play(clip, AudioManager.instance.Data.ButtonClip.Volume);
    }



    private Vector2 GetForce()
    {
        return new Vector2(Mathf.Clamp(InputData.StartPoint.x - InputData.EndPoint.x, -_maxRange, _maxRange),
                                Mathf.Clamp(InputData.StartPoint.y - InputData.EndPoint.y, -_maxRange, _maxRange));
    }

    private void OnDisable()
    {
        InputData.Touched -= _input_Touched;
        InputData.Drag -= _input_Drag;
        InputData.TouchCanceled -= _input_TouchCanceled;
    }
}
