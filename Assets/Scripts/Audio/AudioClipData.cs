using UnityEngine;

[System.Serializable]
public struct AudioClipData
{
    public AudioClip Clip;

    [Range(0f, 1f)]
    public float Volume;
}
