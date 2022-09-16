using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestManager : GenericSingleton<QuestManager>
{
    GameObject player;
    GameObject collectableObj;
    GameObject parent;
    [SerializeField] List<TextMeshProUGUI> objects;
    [SerializeField] List<GameObject> hidePlace;
    public override void Awake()
    {
        player = GameObject.Find("Player");
    }
    void Update()
    {
        if (player.transform.childCount > 0)
        {
            collectableObj = player.transform.GetChild(player.transform.childCount - 1).gameObject;
        }
        if (collectableObj != null)
        {
            var obj = collectableObj.transform.parent;
            parent = obj.gameObject;
        }
        for (int i = 0; i < objects.Count; i++)
        {
            if (player.transform.childCount > 0 && objects[i].gameObject.name == collectableObj.name)
            {
                GameObject bg = objects[i].transform.GetChild(0).gameObject;
                GameObject check = bg.transform.GetChild(0).gameObject;
                check.SetActive(true);
            }
        }
        for (int i = 0; i < hidePlace.Count; i++)
        {
            if (parent != null && parent.name == hidePlace[i].name && objects[i].gameObject.name == collectableObj.name)
            {
                GameObject bg = hidePlace[i].transform.GetChild(0).gameObject;
                Debug.Log(bg);
                GameObject check = bg.transform.GetChild(0).gameObject;
                check.SetActive(true);
            }
        }
    }
}
