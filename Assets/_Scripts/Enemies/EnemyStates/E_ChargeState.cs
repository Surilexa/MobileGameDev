using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_ChargeState : E_State
{
    protected D_ChargeStateData stateData;

    protected bool isPlayerInMinAgroRange;
    protected bool isDetectingLedge;
    protected bool isDetectingWall;
    protected bool isChargeTimeOver;
    protected bool performCloseRangeAction;
    public E_ChargeState(E_Entity entity, E_FiniteStateMachine stateMachine, string animBoolName, D_ChargeStateData stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
        isDetectingLedge = entity.CheckLedge();
        isDetectingWall = entity.CheckWall();

        performCloseRangeAction = entity.CheckPlayerInCloseRangeAction();
    }

    public override void Enter()
    {
        base.Enter();
        entity.SetVelocity(stateData.chargeSpeed);
        isChargeTimeOver = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(Time.time >= startTime + stateData.chargeTime)
        {
            isChargeTimeOver= true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
       
    }
}
