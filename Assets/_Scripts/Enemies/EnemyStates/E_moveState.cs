using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_moveState : E_State
{

    protected D_moveState stateData;

    protected bool isDetectingWall;
    protected bool isDetectingLedge;
    protected bool isPlayerInMinAgroRange;
    //protected bool isPlayerInMaxAgroRange;
    public E_moveState(E_Entity entity, E_FiniteStateMachine stateMachine, string animBoolName, D_moveState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }
    public override void Enter()
    {
        base.Enter();
        entity.SetVelocity(stateData.movementSpeed);

        
       // isPlayerInMaxAgroRange = entity.CheckPlayerInMaxAgroRange();
        
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
    public override void DoChecks()
    {
        base.DoChecks();
        isDetectingLedge = entity.CheckLedge();
        isDetectingWall = entity.CheckWall();
        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
    }
}
