using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_ChargeState : E_ChargeState
{
    private enemy1 enemy;
    public E1_ChargeState(E_Entity entity, E_FiniteStateMachine stateMachine, string animBoolName, D_ChargeStateData stateData, enemy1 enemy) : base(entity, stateMachine, animBoolName, stateData)
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
        if (performCloseRangeAction)
        {
            stateMachine.ChangeState(enemy.meleeAttackState);
        }
        else if (!isDetectingLedge ||isDetectingWall)
        {
            //connect to look for player;
            stateMachine.ChangeState(enemy.lookForPlayerState);
        }

        else if(isChargeTimeOver )
        {
            if(isPlayerInMinAgroRange)
            {
                stateMachine.ChangeState(enemy.playerDetectedState);
            }
            else
            {
                stateMachine.ChangeState(enemy.lookForPlayerState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
