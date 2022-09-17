using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelClick : GenericSingleton<LevelClick>
{
    public GameObject selectLevel;
    public int time;
    public int index;
    public List<Button> Items;
    string a;
    public override void Awake()
    {

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
