using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestManager : GenericSingleton<QuestManager>
{
    GameObject player;
    public GameObject collectableObj;
    public GameObject check;
    public GameObject checkObj;
    GameObject parent;
    [SerializeField] List<TextMeshProUGUI> objects;
    [SerializeField] List<GameObject> hidePlace;
    public override void Awake()
    {
        player = GameObject.Find("EquipPosition");
    }
    void Update()
    {
        if (player.transform.childCount > 0)
        {
            collectableObj = player.transform.GetChild(player.transform.childCount - 1).gameObject;
        }
        //if (collectableObj != null && collectableObj.transform.parent != null)
        //{
        //    var obj = collectableObj.transform.parent;
        //    parent = obj.gameObject;
        //}
        for (int i = 0; i < objects.Count; i++)
        {
            if (player.transform.childCount > 0 && objects[i].gameObject.name == collectableObj.name)
            {
                GameObject bg = objects[i].transform.GetChild(0).gameObject;
                check = bg.transform.GetChild(0).gameObject;
                check.SetActive(true);
            }
        }
        //Complete();
    }
    public void Complete()
    {
        for (int i = 0; i < hidePlace.Count; i++)
        {
            var obj = collectableObj.transform.parent;
            parent = obj.gameObject;
            Debug.Log(parent.name);
            Debug.Log(hidePlace[i].name);
            Debug.Log(objects[i].gameObject.name);
            Debug.Log(collectableObj.name);
            if (parent != null && parent.name == hidePlace[i].name && objects[i].gameObject.name == collectableObj.name)
            {
                //Debug.Log(objects[i].gameObject.name);
                GameObject bg = hidePlace[i].transform.GetChild(0).gameObject;
                Debug.Log(bg);
                checkObj = bg.transform.GetChild(0).gameObject;
                Debug.Log(checkObj);
                check.SetActive(true);
                checkObj.SetActive(true);
            }
        }
    }
}
