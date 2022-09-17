using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehindWallVisible : MonoBehaviour
{
    IEnumerator testEnumarator;
    bool isCanAbility = true;
    public Transform behindWallVisibleBody;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && isCanAbility == true)
        {
            isCanAbility = false;
            StartCoroutine(BehindWallVisibleCoroutine());
        }
    }

    IEnumerator BehindWallVisibleCoroutine() 
    {
        behindWallVisibleBody.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        behindWallVisibleBody.gameObject.SetActive(false);
        StartCoroutine(CoolDown());
    }

    IEnumerator CoolDown()
    {
        StartCoroutine(UIManager.Instance.CooldownTimerBehindWall());
        yield return new WaitForSeconds(15f);
        isCanAbility = true;
    }
}
