using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : GenericSingleton<UIManager>
{
    Canvas canvas;

    private void Start()
    {
        canvas = GameObject.Find("Canvas(Clone)").GetComponent<Canvas>();
    }

    void Update()
    {
        
    }

    public void OpenPickupPanel(bool open)
    {      
        canvas.transform.Find("PickupPanel").gameObject.SetActive(open);
    }

    public void OpenDrawer(bool open)
    {
        canvas.transform.Find("OpenPanel").gameObject.SetActive(open);
    }
}
