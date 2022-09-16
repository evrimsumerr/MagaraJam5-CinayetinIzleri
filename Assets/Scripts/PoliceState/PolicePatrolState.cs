using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolicePatrolState : PoliseBaseState
{
    public override void EnterState(PoliceStateManager police)
    {
        Debug.Log("gf");
        police.alertText.color = Color.yellow;
    }
    public override void UpdateState(PoliceStateManager police)
    {

    }
    public override void OnCollisionEnter(PoliceStateManager police, Collision collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Player"))
        {
            police.alertText.gameObject.SetActive(true);
            police.SwitchState(police.FollowState);
        }
    }

    public override void OnCollisionExit(PoliceStateManager police, Collision collision)
    {

    }
}
