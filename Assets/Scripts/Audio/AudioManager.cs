using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioData _audioData;

    public AudioData Data { get => _audioData; }

    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void Play(AudioClip clip, float volume)
    {
        _audioSource.clip = clip;
        _audioSource.volume = volume;

        _audioSource.Play();
    }
}
