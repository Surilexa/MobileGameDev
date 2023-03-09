using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_DeathState : E_State
{
    protected D_DeathStateData stateData;
    public E_DeathState(E_Entity entity, E_FiniteStateMachine stateMachine, string animBoolName, D_DeathStateData stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        //GameObject.Instantiate(stateData.deathParticles, entity.transform.position, stateData.deathParticles.transform.rotation);

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
    
