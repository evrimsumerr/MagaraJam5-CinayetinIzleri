using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class UIManager : GenericSingleton<UIManager>
{
    Canvas canvas;
    private int cooldownTimer;
    private TextMeshProUGUI timerText;

    private void Start()
    {
        canvas = GameObject.Find("Canvas(Clone)").GetComponent<Canvas>();
        timerText = canvas.transform.Find("TimerPanel").transform.Find("TimerText").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        SetTimer();
    }

    public void OpenPickupPanel(bool open)
    {      
        canvas.transform.Find("PickupPanel").gameObject.SetActive(open);
    }

    public void OpenDrawer(bool open)
    {
        canvas.transform.Find("OpenPanel").gameObject.SetActive(open);
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
}
