using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    public AudioSource audioSource;
    public AudioSource generalAudioSource;
    public AudioClip[] audioClips;
    public AudioClip[] generalAudioClips;
    public Slider slideGeneral;
    public Slider slideEffect;
    private void Awake()
    {
        Instance = this;
    }

    public void PlaySound(int index)
    {
        audioSource.clip = audioClips[index];
        audioSource.Play();
    }
    public void Update()
    {
        generalAudioSource.volume = slideGeneral.value;
        audioSource.volume = slideEffect.value;
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
