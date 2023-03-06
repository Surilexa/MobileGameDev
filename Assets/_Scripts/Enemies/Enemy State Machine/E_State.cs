using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_State
{
    protected E_FiniteStateMachine stateMachine;
    protected E_Entity entity;

    protected float startTime;

    protected string animBoolName;

    public E_State(E_Entity entity, E_FiniteStateMachine stateMachine, string animBoolName)
    {
        this.entity = entity;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
    }
    public virtual void Enter()
    {
        startTime= Time.time;
        entity.anim.SetBool(animBoolName, true);
    }
    public virtual void Exit()
    {
        entity.anim.SetBool(animBoolName, false);
    }
    public virtual void LogicUpdate()
    {

    }
    public virtual void PhysicsUpdate()
    {

    }
}
