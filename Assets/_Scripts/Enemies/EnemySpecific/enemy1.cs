using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1 : E_Entity
{
    public E1_idleState idleState { get; private set; }
    public E1_moveState moveState { get; private set; }
    public E1_PlayerDetectedState playerDetectedState { get; private set; }

    [SerializeField] private D_idleState idleStateData;
    [SerializeField] private D_moveState moveStateData;
    [SerializeField] private D_PlayerDetected detectedData;

    public override void Start()
    {
        base.Start();

        moveState = new E1_moveState(this, stateMachine, "move", moveStateData, this);
        idleState = new E1_idleState(this, stateMachine, "idle", idleStateData, this);

        stateMachine.Initialize(moveState);
    }
}
