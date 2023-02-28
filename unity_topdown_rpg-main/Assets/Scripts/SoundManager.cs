using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource EffectsSource;
    public AudioSource MusicSource;
    // Random pitch adjustment range.
    public float LowPitchRange = .95f;
    public float HighPitchRange = 1.05f;
    public static SoundManager Instance;
    public static List<AudioSource> audios;

    // Initialize the singleton instance.
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        audios = new List<AudioSource>();
    }
    public void Play(AudioSource audioSource)
    {
        EffectsSource = audioSource;
        EffectsSource.Play();
    }
    public void PlayMusic(AudioSource audioSource)
    {
        MusicSource = audioSource;
        MusicSource.Play();
    }
    public void RandomSoundEffect(params AudioSource[] audioSources)
    {
        int randomIndex = Random.Range(0, audioSources.Length);
        float randomPitch = Random.Range(LowPitchRange, HighPitchRange);
        EffectsSource.pitch = randomPitch;
        EffectsSource = audioSources[randomIndex];
        EffectsSource.Play();
    }

    public void MuteSound(AudioSource audioSource)
    {
        audioSource.Stop();
    }

    public void AddToAudio(AudioSource audioSource)
    {
        audios.Add(audioSource);
    }

    public void MuteAll()
    {
        if (audios.Count != 0)
        {
            foreach (AudioSource audioSource in audios)
            {
                if (audioSource.isPlaying)
                {
                    audioSource.volume = 0;
                }
            }
        }
    }

    public void PlayAll()
    {
        if (audios.Count != 0)
        {
            foreach (AudioSource audioSource in audios)
            {
                if (audioSource.isPlaying)
                {
                    audioSource.volume = 1;
                }
            }
        }
    }
}
