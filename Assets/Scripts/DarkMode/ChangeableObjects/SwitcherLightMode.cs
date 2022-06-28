using UnityEngine;
using UnityEngine.UI;

public class SwitcherLightMode : ChangeableDarkMode
{
    [SerializeField] private BackGroundColorMode _backGroundMode;

    [SerializeField] private Image _icon;

    [System.Serializable]
    public struct SpriteMode
    {
        public Sprite LightMode;
        public Sprite DarkMode;
    }

    [SerializeField] private SpriteMode _sprite;

    [Header("Audio")]
    [SerializeField] private AudioSource _audio;

    [System.Serializable]
    public struct AudionMode
    {
        public AudioClip AudioLight;
        public AudioClip AudioDark;
    }

    [SerializeField] private AudionMode _audioMode;

    public override void ActiveDarkMode()
    {
        _icon.sprite = _sprite.DarkMode;
        _audio.clip = _audioMode.AudioDark;
        
    }

    public override void ActiveLightMode()
    {
        _icon.sprite = _sprite.LightMode;
        _audio.clip = _audioMode.AudioLight;
    }

    private void PlayAudio()
    {
        _audio.Play();
    }

    public void OnButtonClicked()
    {
        _backGroundMode.SwitchMode();
        PlayAudio();
    }
}
