using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;
    GameObject player;
    public GameObject collectableObj;
    public GameObject check;
    public GameObject checkObj;
    GameObject parent;
    [SerializeField] List<TextMeshProUGUI> objects;
    [SerializeField] List<GameObject> hidePlace;
    public void Awake()
    {
        Instance = this;
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
            if (player != null && player.transform.childCount > 0 && objects[i].gameObject.name == collectableObj.name)
            {
                GameObject bg = objects[i].transform.GetChild(objects[i].transform.childCount - 1).gameObject;
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
            if (parent != null && parent.name == hidePlace[i].name && objects[i].gameObject.name == collectableObj.name)
            {
                GameObject bg = hidePlace[i].transform.GetChild(hidePlace[i].transform.childCount - 1).gameObject;
                checkObj = bg.transform.GetChild(0).gameObject;
                Debug.Log(check);
                check.SetActive(true);
                checkObj.SetActive(true);
                collectableObj.tag = "Untagged";
                collectableObj.layer = 0;
                collectableObj.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }
}
