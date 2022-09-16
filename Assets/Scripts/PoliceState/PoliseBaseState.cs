using UnityEngine;
public abstract class PoliseBaseState
{
    public abstract void EnterState(PoliceStateManager police);
    public abstract void UpdateState(PoliceStateManager police);
    public abstract void OnCollisionEnter(PoliceStateManager police, Collision collision);
    public abstract void OnCollisionExit(PoliceStateManager police, Collision collision);

}
