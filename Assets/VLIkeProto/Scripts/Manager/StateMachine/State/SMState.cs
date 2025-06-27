using UnityEngine;
public abstract class SMState
{
    protected StatesMachine _machine;
    protected SMState(StatesMachine machine)
    {
        _machine = machine;
    }
    
    
    public virtual void Enter(){}
    public virtual void Exit(){}
    public virtual void Update(){}
    public virtual void FixedUpdate(){} //?
}
