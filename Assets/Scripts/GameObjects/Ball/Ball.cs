using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    [SerializeField] private BallRotation _rotation;

    public bool IsGhost { get; private set; }

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Push(Vector2 velocity, bool isGhost = false)
    {
        IsGhost = isGhost;

        _rb.bodyType = RigidbodyType2D.Dynamic;
        _rb.AddForce(velocity, ForceMode2D.Impulse);
        if (!IsGhost)
            _rotation.Active();
    }

    public void AssignToBasket(Transform basket)
    {
        _rotation.Deactive();
        _rb.bodyType = RigidbodyType2D.Static;
        transform.parent = basket;
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!IsGhost)
        {
            _rotation.Deactive();

            if (SettingsData.instance.Settings.VibrationSetting.Get())
                Handheld.Vibrate();
        }
    }
}
