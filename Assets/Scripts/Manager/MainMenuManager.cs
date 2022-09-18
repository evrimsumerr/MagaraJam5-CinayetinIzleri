using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Transform SettingsPanel, CreditsPanel, LevelPanel, background, backgroundNoText;
    public Button PlayButton;
    public AudioSource audioSource;
    public AudioSource effectSource;
    public AudioClip audioClip;
    public AudioClip effectClip;
    public Slider slideGeneral;
    public Slider slideEffect;

    private void Start()
    {
        var canvas = GameObject.Find("Canvas");
        SettingsPanel = canvas.transform.Find("SettingsPanel");
        CreditsPanel = canvas.transform.Find("CreditsPanel");
        LevelPanel = canvas.transform.Find("LevelPanel");
        PlayButton = canvas.transform.Find("PlayButton").GetComponent<Button>();
        background = canvas.transform.Find("Background");
        backgroundNoText = canvas.transform.Find("BackgroundNoText");
        audioSource.clip = audioClip;
        effectSource.clip = effectClip;
        audioSource.Play();
    }
    
    public void Update()
    {
        audioSource.volume = slideGeneral.value;
        effectSource.volume = slideEffect.value;
    }

    public void OpenSettingsMenu()
    {
        SettingsPanel.gameObject.SetActive(true);
        effectSource.Play();
    }

    public void OpenCreditsMenu()
    {
        CreditsPanel.gameObject.SetActive(true);
        effectSource.Play();
    }

    public void CloseSettingsMenu()
    {
        SettingsPanel.gameObject.SetActive(false);
        effectSource.Play();
    }

    public void CloseCreditsMenu()
    {
        CreditsPanel.gameObject.SetActive(false);
        effectSource.Play();
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void OpenStartGamePanel()
    {
        LevelPanel.gameObject.SetActive(true);
        PlayButton.gameObject.SetActive(true);
        background.gameObject.SetActive(false);
        backgroundNoText.gameObject.SetActive(true);
        effectSource.Play();
    }
    
    public void CloseStartGamePanel()
    {
        LevelPanel.gameObject.SetActive(false);
        PlayButton.gameObject.SetActive(false);
        background.gameObject.SetActive(true);
        backgroundNoText.gameObject.SetActive(false);
        effectSource.Play();
    }
}
