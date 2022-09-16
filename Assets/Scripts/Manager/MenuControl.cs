using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] TextMeshProUGUI openText;
    [SerializeField] TextMeshProUGUI closeText;
    [SerializeField] Image questsBg;
    bool openState;
    bool closeState;
    bool questsBgState;
    public void OpenQuests()
    {
        openState = openText.gameObject.activeSelf;
        closeState = closeText.gameObject.activeSelf;
        questsBgState = questsBg.gameObject.activeSelf;
        closeText.gameObject.SetActive(!closeState);
        openText.gameObject.SetActive(!openState);
        questsBg.gameObject.SetActive(!questsBgState);
    }
}

