using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_idleState : E_idleState
{
    private enemy1 enemy;
    public E1_idleState(E_Entity entity, E_FiniteStateMachine stateMachine, string animBoolName, D_idleState stateData, enemy1 enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
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

        if (isIdleTimeOver)
        {
            stateMachine.ChangeState(enemy.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
