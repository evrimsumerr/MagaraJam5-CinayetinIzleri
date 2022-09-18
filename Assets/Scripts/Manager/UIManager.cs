using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using StarterAssets;
public class UIManager : MonoBehaviour
{
    GameObject player;
    public static UIManager Instance;
    Canvas canvas;
    private int cooldownTimer;
    public TextMeshProUGUI timerText;
    public Transform mainMenuPanel;
    public Transform settingsPanel;
    public Transform timerPanel;
    public Button resumeButton, settingsButton, mainMenuButton, exitButton;
    public GameObject gameOverPanel;
    private void Awake()
    {
        player = GameObject.Find("PlayerCapsule");
        Instance = this;
    }

    private void Start()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        player.GetComponent<StarterAssetsInputs>().cursorInputForLook = true;
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        mainMenuPanel = canvas.transform.Find("MainMenuPanel");
        timerPanel = canvas.transform.Find("TimerPanel");
        resumeButton = mainMenuPanel.Find("Background").transform.Find("Resume").GetComponent<Button>();
        settingsButton = mainMenuPanel.Find("Background").transform.Find("Settings").GetComponent<Button>();
        mainMenuButton = mainMenuPanel.Find("Background").transform.Find("MainMenu").GetComponent<Button>();
        exitButton = mainMenuPanel.Find("Background").transform.Find("Exit").GetComponent<Button>();
        if (timerPanel != null)
        {
            timerText = timerPanel.Find("TimerText").GetComponent<TextMeshProUGUI>();
        }
        settingsPanel = mainMenuPanel.transform.Find("SettingsMenu");
        resumeButton.onClick.AddListener(SettingMenuClose);
        settingsButton.onClick.AddListener(SettingsOpen);
    }

    private void Update()
    {
        if (gameOverPanel != null && gameOverPanel.activeSelf)
        {
            Cursor.visible = true;
            Time.timeScale = 0;
            player.GetComponent<StarterAssetsInputs>().cursorInputForLook = false;
        }
        if (!mainMenuPanel.gameObject.activeSelf)
        {
            settingsPanel.gameObject.SetActive(false);
            Cursor.visible = false;
        }
        else
        {
            Cursor.visible = true;
        }
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
        if (timerText != null)
        {
            timerText.text = GameManager.Instance.timer.ToString();
        }
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
        //Cursor.visible = true;
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
        if (!mainMenuPanel.gameObject.activeSelf && !gameOverPanel.activeSelf)
        {
            player.GetComponent<StarterAssetsInputs>().cursorInputForLook = false;
            settingsButton.gameObject.SetActive(true);
            mainMenuButton.gameObject.SetActive(true);
            exitButton.gameObject.SetActive(true);
            mainMenuPanel.gameObject.SetActive(true);
            //mainMenuPanel.localPosition = new Vector2(0, -Screen.height);
            //mainMenuPanel.LeanMoveLocalY(0, 1f).setEaseOutExpo();
        }
    }
    public void SettingMenuClose()
    {
        player.GetComponent<StarterAssetsInputs>().cursorInputForLook = true;
        Time.timeScale = 1;
        mainMenuPanel.gameObject.SetActive(false);
        //mainMenuPanel.LeanMoveLocalY(-Screen.height, 1f).setEaseInExpo().setOnComplete(() => { mainMenuPanel.gameObject.SetActive(false); });
    }
    public void SettingsOpen()
    {
        settingsButton.gameObject.SetActive(false);
        mainMenuButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
        settingsPanel.gameObject.SetActive(true);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
