using System;
using UnityEngine;
using UnityEngine.UI;

public class ItemCustomize: MonoBehaviour
{
    [SerializeField] private Image _sprite;

    [SerializeField] private GameObject Close;

    [SerializeField] private Text _costText;

    [SerializeField] private GameObject SelectedImage;

    private bool _bought;
    public bool Bought { get => _bought; }

    private bool _selected;
    public bool Selected { get => _selected; }

    public Action<ItemCustomize> Clicked;

    private Skin _skin;
    public Skin Skin { get => _skin; }

    public void Init(Skin skin)
    {
        _skin = skin;
        SetCost(skin.Cost);
        SetSkin(skin.Sprite);

        _bought = skin.Bought;

        if (Bought)
        {
            Close.gameObject.SetActive(false);
        }
    }

    public void OnItemClicked()
    {
        Clicked?.Invoke(this);
    }

    public void SetSkin(Sprite sprite)
    {
        _sprite.sprite = sprite;
    }

    public void SetCost(int cost)
    {
        _costText.text = cost.ToString();
    }

    public void Buy()
    {
        _bought = true;
        Close.SetActive(false);
    }

    public void Select()
    {
        _selected = true;
        SelectedImage.SetActive(true);
    }

    public void UnSelect()
    {
        _selected = false;
        SelectedImage.SetActive(false);
    }
}
