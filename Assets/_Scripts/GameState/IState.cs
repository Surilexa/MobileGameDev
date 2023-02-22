using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IState
{
    public float StateDuration { get; private set; } = 0;

    // automatically gets called in the State machine. Allows you to delay flow if desired
    public virtual void Enter()
    {
        StateDuration = 0;
    }
    // allows simulation of Update() method without a MonoBehaviour attached
    public virtual void Tick()
    {
        StateDuration += Time.deltaTime;
    }
    // allows simulatin of FixedUpdate() method without a MonoBehaviour attached
    public virtual void FixedTick()
    {

    }
    // automatically gets called in the State machine. Allows you to delay flow if desired
    public virtual void Exit()
    {
        
    }
}
