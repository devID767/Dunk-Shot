using System;
using UnityEngine;
using UnityEngine.Events;

public class Customize : MonoBehaviour
{
    [SerializeField] private Skin[] _skins;

    [SerializeField] private ItemCustomize _item;

    [SerializeField] private Transform Content;


    private ItemCustomize[] _items;
    public ItemCustomize[] Items { get => _items; }

    private ItemCustomize _selectedItem;


    [SerializeField] private UnityEvent DoubleSelected;
    public static event Action<Skin> SkinChanged;

    private void Awake()
    {
        Init();
    }

    public void OnItemClicked(ItemCustomize item)
    {
        if (item.Bought)
        {
            if (item.Selected)
            {
                DoubleSelected?.Invoke();
            }
            else
            {
                Select(item);
            }
        }
        else
        {
            Buy(item);
        }
    }

    private void Buy(ItemCustomize item)
    {
        if (PointData.instance.Coins.DecreaseOn(item.Skin.Cost))
        {
            item.Buy();
            Select(item);
        }
    }

    public void Select(ItemCustomize item)
    {
        UnSelect();
        item.Select();

        _selectedItem = item;

        SkinChanged?.Invoke(item.Skin);
    }

    public void UnSelect()
    {
        _selectedItem.UnSelect();
    }

    public void SetDataToSkins(bool[] bought, bool[] selected)
    {
        //Init();

        if (bought.Length != 0)
        {
            for (int i = 0; i < _items.Length; i++)
            {
                if (bought[i])
                {
                    _items[i].Buy();
                }

                if (selected[i])
                {
                    Select(_items[i]);
                }
            }
        }
    }

    private void Init()
    {
        _items = new ItemCustomize[_skins.Length];
        for (int i = 0; i < _items.Length; i++)
        {
            var item = Instantiate(_item, Content);
            var skin = _skins[i];

            item.Init(skin);
            item.Clicked = OnItemClicked;

            if (skin.Selected)
            {
                _selectedItem = item;
                item.Select();
                SkinChanged?.Invoke(skin);
            }

            _items[i] = item;
        }
    }
}