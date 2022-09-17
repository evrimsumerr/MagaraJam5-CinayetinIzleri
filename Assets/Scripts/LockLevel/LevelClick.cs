using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelClick : GenericSingleton<LevelClick>
{
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
        index = int.Parse(button.name);
    }
}
