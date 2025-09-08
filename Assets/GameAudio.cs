using UnityEngine;
using UnityEngine.Rendering;

public class GameAudio : MonoBehaviour
{
    public static GameAudio Instance; // Singleton instance for easy access

    public AudioSource BackgroundMusic;
    public AudioSource sfxMusic;
    public AudioClip CrashClip;
    public AudioClip ScoreClip;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep this object across scenes
        }
        else
        {
            Destroy(gameObject); // Ensure only one instance exists
        }
    }

    public void PlayCrush()
    {
        sfxMusic.PlayOneShot(CrashClip);
    }

    public void PlayScore()
    {
        sfxMusic.PlayOneShot(ScoreClip);
    }

    /* OPTIONAL 
      public void PlayBackgroundMusic()
    {
        if (!BackgroundMusic.isPlaying)
        {
            BackgroundMusic.Play();
        }
    }*/

    public void StopMusic()
    {
        BackgroundMusic.Stop();
    }


}
