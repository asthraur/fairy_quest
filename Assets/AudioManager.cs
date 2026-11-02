using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource noiseSource;

    [SerializeField] AudioSource sfxSource;

    public AudioClip backgroundMusic;
    public AudioClip forestSounds;

    void Start()
    {
        musicSource.loop = true;
        musicSource.volume = 0.4f;
        musicSource.clip = backgroundMusic;
        musicSource.Play();

        noiseSource.loop = true;
        noiseSource.volume = 0.1f;
        noiseSource.clip = forestSounds;
        noiseSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

}
