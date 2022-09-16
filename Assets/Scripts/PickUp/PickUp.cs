using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] Transform equipPos;
    [SerializeField] float distance;
    [SerializeField] Transform playerCamera;
    GameObject currentObject;
    GameObject obj;
    bool canGrab;
   

    // Update is called once per frame
    void Update()
    {
        CheckObjects();
        if (canGrab)
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
        if (currentObject != null)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Drop();
            }
        }
    }

    void CheckObjects()
    {
        RaycastHit hit;

        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hit, distance))
        {
            if (hit.transform.tag == "CanGrab")
            {
                Debug.Log("grab it");
                canGrab = true;
                obj = hit.transform.gameObject;
            }
        }
        else
        {
            canGrab = false;
        }
    }
    void PickingUp()
    {
        currentObject = obj;
        currentObject.transform.position = equipPos.position;
        currentObject.transform.parent = equipPos;
        currentObject.transform.localEulerAngles = new Vector3(0, 0, 0);
        currentObject.GetComponent<Rigidbody>().isKinematic = true;
    }
    void Drop()
    {
        currentObject.transform.parent = null;
        currentObject.GetComponent<Rigidbody>().isKinematic = false;
        currentObject = null;
    }
}
