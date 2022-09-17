using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : GenericSingleton<SoundManager>
{
    public AudioSource audioSource;
    public AudioSource generalAudioSource;
    public AudioClip[] audioClips;
    public AudioClip[] generalAudioClips;

    public void PlaySound(int index)
    {
        audioSource.clip = audioClips[index];
        audioSource.Play();
    }

    public void PlayGeneralSound()
    {
        var index = Random.Range(0, generalAudioClips.Length);
        generalAudioSource.clip = generalAudioClips[index];
        generalAudioSource.Play();
    }
    
    public void StopSound()
    {
        float startVolume = audioSource.volume;
        audioSource.volume = Mathf.Lerp(audioSource.volume, 0,2);
        
        audioSource.Stop();
        audioSource.volume = startVolume;
    }
}
