using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_DeathState : E_DeathState
{
    private enemy1 enemy;
    public E1_DeathState(E_Entity entity, E_FiniteStateMachine stateMachine, string animBoolName, D_DeathStateData stateData, enemy1 enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
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
