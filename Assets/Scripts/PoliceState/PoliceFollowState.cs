using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PoliceFollowState : PoliseBaseState
{
    float time;
    public override void EnterState(PoliceStateManager police)
    {
        time = 2;
    }
    public override void UpdateState(PoliceStateManager police)
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            Debug.Log("sadadsa");
            police.alertText.color = Color.red;
        }
    }
    public override void OnCollisionEnter(PoliceStateManager police, Collision collision)
    {

    }

    public override void OnCollisionExit(PoliceStateManager police, Collision collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Player"))
        {
            time = 0;
            police.alertText.color = Color.yellow;
            police.alertText.gameObject.SetActive(false);
            police.SwitchState(police.PatrolState);
        }
    }
}
