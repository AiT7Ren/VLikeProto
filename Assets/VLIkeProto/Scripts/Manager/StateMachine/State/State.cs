using UnityEngine;
public abstract class State<T> where T : State<T>
{
    protected StatesMachine<T> _machine;

    public State(StatesMachine<T> machine)
    {
        _machine = machine;
    }
    
    
    public virtual void Enter(){}
    public virtual void Exit(){}
    public virtual void Update(){}
    public virtual void FixedUpdate(){} //?
}
