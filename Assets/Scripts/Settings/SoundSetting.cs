using UnityEngine;
using UnityEngine.Audio;

public class SoundSetting : MonoBehaviour, ISettingable
{
    [SerializeField] private Switcher _switcher;
    [SerializeField] private AudioMixer _audioMixer;

    private bool _soundOn = true;

    private void OnEnable()
    {
        Update();
    }

    public bool Get()
    {
        return _soundOn;
    }

    public void Set(bool flag)
    {
        _soundOn = flag;
        Update();
    }

    public void Switch()
    {
        _soundOn = !_soundOn;
        Update();
    }

    public void Update()
    {
        _switcher.Set(_soundOn);

        if (_soundOn)
        {
            _audioMixer.SetFloat("MasterVolume", 0);
        }
        else
        {
            _audioMixer.SetFloat("MasterVolume", -80);
        }
    }
}

