using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_LookForPlayerState : E_LookForPlayerState
{
    private enemy1 enemy;
    public E1_LookForPlayerState(E_Entity entity, E_FiniteStateMachine stateMachine, string animBoolName, D_LookForPlayerData stateData, enemy1 enemy) : base(entity, stateMachine, animBoolName, stateData)
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

        if (isPlayerInMinAgroRange)
        {
            stateMachine.ChangeState(enemy.playerDetectedState);

        }
        else if(isAllTurnsDone)
        {
            stateMachine.ChangeState(enemy.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
