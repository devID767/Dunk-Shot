using UnityEngine;

[CreateAssetMenu(menuName ="Skins", fileName ="Skin")]
public class Skin : ScriptableObject
{
    [SerializeField] private Sprite _sprite;

    public Sprite Sprite { get => _sprite; }


    [SerializeField] private int _cost = 100;
    public int Cost { get => _cost; }

    [SerializeField] private bool _bought;
    public bool Bought { get => _bought; }

    [SerializeField] private bool _selected;
    public bool Selected { get => _selected; }
}
