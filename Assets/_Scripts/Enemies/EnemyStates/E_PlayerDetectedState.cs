using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_PlayerDetectedState : E_State
{
    protected D_PlayerDetected stateData;

    protected bool isPlayerInMinAgroRange;
    protected bool isPlayerInMaxAgroRange;
    protected bool performLongRangeAction;
    protected bool performCloseRangeAction;
    protected bool isDetectingLedge;

    public E_PlayerDetectedState(E_Entity etity, E_FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetected stateData) : base(etity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
        isPlayerInMaxAgroRange = entity.CheckPlayerInMaxAgroRange();
        isDetectingLedge = entity.CheckLedge();
        performCloseRangeAction = entity.CheckPlayerInCloseRangeAction();
    }

    public override void Enter()
    {
        base.Enter();
        performLongRangeAction = false;
        entity.SetVelocity(0f);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

      //  core.Movement.SetVelocityX(0f);

       if (Time.time >= startTime + stateData.LongRangeActionTime)
       {
         performLongRangeAction = true;
       }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
