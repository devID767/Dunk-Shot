using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Audio : MonoBehaviour
{
    private AudioSource _audioSource;

    public void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Play(AudioClip clip, float volume)
    {
        _audioSource.clip = clip;
        _audioSource.volume = volume;

        _audioSource.Play();
    }
}