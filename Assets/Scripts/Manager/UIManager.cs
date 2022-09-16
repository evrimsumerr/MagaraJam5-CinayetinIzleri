using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : GenericSingleton<UIManager>
{
    [SerializeField] TextMeshProUGUI openText;
    [SerializeField] TextMeshProUGUI closeText;
    [SerializeField] Image questsBg;
    bool openState;
    bool closeState;
    bool questsBgState;
    public void OpenQuests()
    {

    }

    void Update()
    {
        openState = openText.gameObject.activeSelf;
        closeState = closeText.gameObject.activeSelf;
        questsBgState = questsBg.gameObject.activeSelf;
        closeText.gameObject.SetActive(!closeState);
        openText.gameObject.SetActive(!openState);
        questsBg.gameObject.SetActive(!questsBgState);
    }
}
