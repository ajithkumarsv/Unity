using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    

    private AudioSource[] audioSources;

    private void Awake()
    {
        
        audioSources = GetComponentsInChildren<AudioSource>();
    }

    public void PlaySound(AudioClip clip, float volume = 1.0f)
    {
        // Find an available audio source
        AudioSource source = GetAvailableAudioSource();
        if (source == null)
        {
            Debug.LogWarning("No available audio sources!");
            return;
        }

        source.volume = volume;
        source.clip = clip;
        source.Play();
    }

    private AudioSource GetAvailableAudioSource()
    {
        foreach (AudioSource source in audioSources)
        {
            if (!source.isPlaying)
            {
                return source;
            }
        }
        return null;
    }

    public void StopAllSounds()
    {
        foreach (AudioSource source in audioSources)
        {
            source.Stop();
        }
    }

    public void SetMasterVolume(float volume)
    {
        AudioListener.volume = volume;
    }
}
