using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _movingSpeed;
    
    private Vector2 _offset;

    private Camera _camera;

    private void Start()
    {
        _camera = GetComponent<Camera>();
        _offset = _camera.transform.position - _target.position;
    }

    void FixedUpdate()
    {
        if (_target && GameStatus.Get() == EGameStatus.IsPlaying)
        {
            var pos = new Vector3(
                transform.position.x,
                Mathf.Clamp(_target.position.y + _offset.y, transform.position.y - _offset.y, _target.position.y + _offset.y),
                transform.position.z);

            transform.position = Vector3.Lerp(transform.position, pos, _movingSpeed * Time.deltaTime);
        }
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }
}
