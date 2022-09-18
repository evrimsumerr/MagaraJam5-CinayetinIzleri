using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : GenericSingleton<UIManager>
{
    Canvas canvas;
    private int cooldownTimer;
    public TextMeshProUGUI timerText;
    public Transform mainMenuPanel;
    public Transform settingsPanel;
    public Transform timerPanel;
    public Button resumeButton, settingsButton, mainMenuButton, exitButton;

    private void Start()
    {
        Cursor.visible = false;
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        mainMenuPanel = canvas.transform.Find("MainMenuPanel");
        timerPanel = canvas.transform.Find("TimerPanel");
        resumeButton = mainMenuPanel.Find("Background").transform.Find("Resume").GetComponent<Button>();
        settingsButton = mainMenuPanel.Find("Background").transform.Find("Settings").GetComponent<Button>();
        mainMenuButton = mainMenuPanel.Find("Background").transform.Find("MainMenu").GetComponent<Button>();
        exitButton = mainMenuPanel.Find("Background").transform.Find("Exit").GetComponent<Button>();
        timerText = timerPanel.Find("TimerText").GetComponent<TextMeshProUGUI>();
        settingsPanel = canvas.transform.Find("SettingsPanel");
        resumeButton.onClick.AddListener(SettingMenuClose);
    }

    private void Update()
    {
        SetTimer();
    }

    public void OpenPickupPanel(bool open)
    {      
        canvas.transform.Find("PickupPanel").gameObject.SetActive(open);
    }

    public void OpenDrawer(bool open, string text)
    {
        canvas.transform.Find("OpenPanel").gameObject.SetActive(open);
        canvas.transform.Find("OpenPanel").transform.Find("Image").transform.Find("OpenCloseText").GetComponent<TextMeshProUGUI>().text = text;
    }
    
    public void OpenPlacePanel(bool open)
    {
        canvas.transform.Find("PlacePanel").gameObject.SetActive(open);
    }

    void SetTimer()
    {
        timerText.text = GameManager.Instance.timer.ToString();
    }
    
    public IEnumerator CooldownTimerBehindWall()
    {
        cooldownTimer = 15;
        var cooldownText = canvas.transform.Find("SkillPanel").transform.Find("WallBehindBackground").transform.Find("Image").transform.Find("CooldownText").GetComponent<TextMeshProUGUI>();
        while (cooldownTimer > 0)
        {
            cooldownText.text = cooldownTimer.ToString();
            yield return new WaitForSeconds(1);
            cooldownTimer--;
        }
        cooldownText.text = "";
    }
    public void GameOver(bool open)
    {   
        canvas.transform.Find("GameOverPanel").gameObject.SetActive(open);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SoundManager.Instance.PlayGeneralSound();
        Debug.Log("restart");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);

    }
    public void SettingMenuOpen()
    {
        Cursor.visible = true;
        if (!mainMenuPanel.gameObject.activeSelf)
        {
            mainMenuPanel.gameObject.SetActive(true);
            mainMenuPanel.localPosition = new Vector2(0, -Screen.height);
            mainMenuPanel.LeanMoveLocalY(0, 1f).setEaseOutExpo();
        }
    }
    public void SettingMenuClose()
    {
        Cursor.visible = false;
        mainMenuPanel.LeanMoveLocalY(-Screen.height, 1f).setEaseInExpo().setOnComplete(() => { mainMenuPanel.gameObject.SetActive(false); });
    }
    
}
