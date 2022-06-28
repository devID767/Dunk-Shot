using UnityEngine;

public class AudioData : MonoBehaviour
{
    public AudioClipData ButtonClip;

    [System.Serializable]
    public struct Release
    {
        public AudioClipData High;
        public AudioClipData Mid;
        public AudioClipData Low;
    }

    public Release ReleaseBall;

    [System.Serializable]
    public struct BasketAudio
    {
        public AudioClipData Spawn;
        public AudioClipData Net;
        public AudioClipData Hoop;
    }

    public BasketAudio basketAudio;

    public AudioClipData Border;

    public AudioClipData Bouncy;

    public AudioClipData Wall;

    [System.Serializable]
    public struct ScorePerfect
    {
        //public AudioClipData Simple;

        //public AudioClipData One;
        //public AudioClipData Two;
        //public AudioClipData Three;
        //public AudioClipData Four;
        //public AudioClipData Five;
        //public AudioClipData Six;
        //public AudioClipData Seven;
        //public AudioClipData Eight;
        //public AudioClipData Nine;
        //public AudioClipData Ten;

        public AudioClipData[] Clips;
    }

    public ScorePerfect Score;

    public AudioClipData Coin;

    public AudioClipData Gameover;
}
