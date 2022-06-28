using UnityEngine;

public class BasketRotation : MonoBehaviour
{
    private bool _on;

    private void OnEnable()
    {
        InputData.Drag += _input_Drag;
    }

    public void On()
    {
        transform.rotation = Quaternion.identity;
        _on = true;
    }

    public void Off()
    {
        _on = false;
    }

    private void _input_Drag()
    {
        if (_on)
        {
            Rotate(InputData.StartPoint - InputData.EndPoint);
        }
    }

    private void Rotate(Vector3 direction)
    {
        Vector3 dir = Vector3.zero;

        dir.x = direction.x;
        dir.z = direction.y;

        if (dir.sqrMagnitude > 1)
            dir.Normalize();

        var rot = Quaternion.LookRotation(dir);

        rot.z = rot.y;
        rot.y = 0;

        rot.z *= -1;

        transform.rotation = rot;
    }

    private void OnDisable()
    {
        InputData.Drag -= _input_Drag;
    }
}
