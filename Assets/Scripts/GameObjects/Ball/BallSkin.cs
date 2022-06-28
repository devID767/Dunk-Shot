using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BallSkin : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        Customize.SkinChanged += Customize_SkinChanged;
    }
    private void Customize_SkinChanged(Skin skin)
    {
        SelectSkin(skin.Sprite);
    }

    public void SelectSkin(Sprite skin)
    {
        _spriteRenderer.sprite = skin;
    }
    private void OnDestroy()
    {
        Customize.SkinChanged -= Customize_SkinChanged;
    }
}
