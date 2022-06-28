using System.Collections;
using UnityEngine;

public class BallRotation : MonoBehaviour
{
    [SerializeField] private float _maxAnglePerTime;
    [SerializeField] private float _minAnglePerTime;

    private IEnumerator _currentCoroutine;

    public void Active()
    {
        _currentCoroutine = Rotate();
        StartCoroutine(_currentCoroutine);
    }

    private IEnumerator Rotate()
    {
        float anglePerTime = Random.Range(_minAnglePerTime, _maxAnglePerTime);

        if (Random.Range(0, 101) < 50)
        {
            anglePerTime *= -1f;
        }

        while (true)
        {

            transform.Rotate(0, 0, anglePerTime, Space.Self);
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    public void Deactive()
    {
        if(_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);
    }
}
