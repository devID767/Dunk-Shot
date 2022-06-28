using System;
using UnityEngine;

[RequireComponent(typeof(AudioClip))]
public class ButtonAudio : MonoBehaviour
{
    private AudioClip _audioClip;

    private float _volume;

    public void Play()
    {
        _audioClip = AudioManager.instance.Data.ButtonClip.Clip;
        _volume = AudioManager.instance.Data.ButtonClip.Volume;

        AudioManager.instance.Play(_audioClip, _volume);
    }
}
