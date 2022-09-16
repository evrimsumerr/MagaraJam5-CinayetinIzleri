using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PoliceStateManager : MonoBehaviour
{
    public TextMeshProUGUI alertText;
    PoliseBaseState currentState;
    public PolicePatrolState PatrolState = new PolicePatrolState();
    public PoliceFollowState FollowState = new PoliceFollowState();
    void Start()
    {
        currentState = PatrolState;
        currentState.EnterState(this);
    }
    private void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionEnter(this, collision);
    }
    private void OnCollisionExit(Collision collision)
    {
        currentState.OnCollisionExit(this, collision);
    }
    void Update()
    {
        currentState.UpdateState(this);
    }
    public void SwitchState(PoliseBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
