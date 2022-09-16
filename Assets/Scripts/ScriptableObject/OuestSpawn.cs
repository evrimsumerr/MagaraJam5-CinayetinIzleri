using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuestSpawn : MonoBehaviour
{
    [SerializeField] QuestMenu menu;
    void Start()
    {
        for (int i = 0; i < menu.questMenu.Count; i++)
        {
            if (GameManager.Instance.levelIndex - 1 == i)
            {
                Instantiate(menu.questMenu[i]);
            }
        }
    }
}
