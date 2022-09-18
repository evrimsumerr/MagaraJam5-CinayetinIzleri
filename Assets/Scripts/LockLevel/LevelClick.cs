using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelClick : MonoBehaviour
{
    public static LevelClick Instance;
    public GameObject selectLevel;
    public int time;
    public int index;
    public List<Button> Items;
    string a;
    public void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Select(Button button)
    {
        selectLevel = button.gameObject;
        time = selectLevel.GetComponent<LevelTime>().time;
        PlayerPrefs.SetInt("Time", time);
        index = int.Parse(button.name);
    }
}
