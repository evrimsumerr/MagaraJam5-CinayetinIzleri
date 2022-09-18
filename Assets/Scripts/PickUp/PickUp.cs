using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PickUp : MonoBehaviour
{
    [SerializeField] Transform equipPos;
    [SerializeField] float distance;
    [SerializeField] Transform playerCamera;
    GameObject currentObject; 
    GameObject openableObject; 
    GameObject placeObject;
    GameObject obj;
    [SerializeField]bool canGrap;
    [SerializeField]bool canOpen;
    [SerializeField] bool canPlace;
    

    // Update is called once per frame
    void Update()
    {
        CheckObjects();
        if (canGrap)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                
                if (currentObject == null)
                {
                    PickingUp();
                }
                if (currentObject != null)
                {
                    Drop();
                    PickingUp();
                }
            }
        }
        if (canOpen)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (openableObject != null)
                {
                    OpenDrawer();
                }
            }
        }
        if (canPlace)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (placeObject != null)
                {
                    PlaceObject();
                }
            }
        }
        if (currentObject != null)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Drop();
            }
        }
    }

    private void OpenDrawer()
    {
        if (openableObject.gameObject.tag == "Drawer")
        {
            openableObject.LeanMoveX(openableObject.transform.position.x + 0.28f, 0.7f).setEaseInExpo();
            openableObject.tag = "DrawerOpen";
            SoundManager.Instance.PlaySound(1);
        }
        else if (openableObject.gameObject.tag == "DrawerOpen")
        {
            openableObject.LeanMoveX(openableObject.transform.position.x - 0.28f, 0.7f).setEaseInExpo();
            openableObject.tag = "Drawer";
            SoundManager.Instance.PlaySound(2);
        }
    }

    void PlaceObject()
    {
        if (QuestManager.Instance.check != null && QuestManager.Instance.checkObj == null)
        {
            QuestManager.Instance.check.SetActive(false);
        }
        if (currentObject != null)
        {
            currentObject.transform.position = new Vector3(placeObject.transform.position.x, placeObject.transform.position.y + 1f, placeObject.transform.position.z);
            currentObject.transform.parent = null;
            currentObject.GetComponent<Rigidbody>().isKinematic = false;
            currentObject = null;
        }
    }

    void CheckObjects()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(Camera.main.transform.position, playerCamera.forward, out hit, distance, 1 << 8))
        {
            if (hit.transform.tag == "CanGrab")
            {
                UIManager.Instance.OpenPickupPanel(true);
                canGrap = true;
                obj = hit.transform.gameObject;
            }
        }
        else
        {
            UIManager.Instance.OpenPickupPanel(false);
            canGrap = false;
        }
        
        if (Physics.Raycast(Camera.main.transform.position, playerCamera.forward, out hit, distance, 1 << 9))
        {
            if (hit.transform.tag == "Drawer" || hit.transform.tag == "DrawerOpen")
            {
                UIManager.Instance.OpenDrawer(true, hit.transform.tag == "Drawer" ? "Open" : "Close");
                canOpen = true;
                openableObject = hit.transform.gameObject;
            }
        }
        else
        {
            UIManager.Instance.OpenDrawer(false, "");
            canOpen = false;
            openableObject = null;
        }

        if (Physics.Raycast(Camera.main.transform.position, playerCamera.forward, out hit, distance, 1 << 10))
        {
            if (hit.transform.tag == "HideObjects" && currentObject != null)
            {
                UIManager.Instance.OpenPlacePanel(true);
                canPlace = true;
                placeObject = hit.transform.gameObject;
            }
        }
        else
        {
            UIManager.Instance.OpenPlacePanel(false);
            canPlace = false;
            placeObject = null;
        }
        
    }
    void PickingUp()
    {
        currentObject = obj;
        currentObject.transform.position = equipPos.position;
        currentObject.transform.parent = equipPos;
        currentObject.transform.localEulerAngles = new Vector3(-90, 0, -120);
        currentObject.GetComponent<Rigidbody>().isKinematic = true;
    }
    void Drop()
    {
        //if (placeObject != null)
        //{
        //    currentObject.transform.position = new Vector3(placeObject.transform.position.x, placeObject.transform.position.y + 1f, placeObject.transform.position.z);
        //}
        currentObject.transform.parent = null;
        currentObject.GetComponent<Rigidbody>().isKinematic = false;
        currentObject = null;
        //if (QuestManager.Instance.collectableObj.transform.parent != null)
        //{
        //    QuestManager.Instance.collectableObj.transform.parent = null;
        //}
        if (QuestManager.Instance.check != null && QuestManager.Instance.collectableObj.transform.parent == null)
        {
            QuestManager.Instance.check.SetActive(false);
        }
    }
}
