using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1 : E_Entity
{
    public E1_idleState idleState { get; private set; }
    public E1_moveState moveState { get; private set; }
    public E1_PlayerDetectedState playerDetectedState { get; private set; }

    public E1_ChargeState chargeState { get; private set; }

    public E1_LookForPlayerState lookForPlayerState { get; private set; }

    public E1_MeleeAttackState meleeAttackState { get; private set; }


    [SerializeField] private D_idleState idleStateData;
    [SerializeField] private D_moveState moveStateData;
    [SerializeField] private D_PlayerDetected detectedData;
    [SerializeField] private D_ChargeStateData chargeStateData;
    [SerializeField] private D_LookForPlayerData lookForPlayerStateData;
    [SerializeField] private D_MeleeAttackData meleeAttackData;


    [SerializeField] private Transform meleeAttackPosition;
    public override void Start()
    {
        base.Start();

        moveState = new E1_moveState(this, stateMachine, "move", moveStateData, this);
        idleState = new E1_idleState(this, stateMachine, "idle", idleStateData, this);
        playerDetectedState = new E1_PlayerDetectedState(this, stateMachine, "playerDetected", detectedData, this);
        chargeState = new E1_ChargeState(this, stateMachine, "charge", chargeStateData, this);
        lookForPlayerState = new E1_LookForPlayerState(this, stateMachine, "lookForPlayer", lookForPlayerStateData, this);
        meleeAttackState = new E1_MeleeAttackState(this, stateMachine, "meleeAttack", meleeAttackPosition, meleeAttackData, this);

        stateMachine.Initialize(moveState);
    }
    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackData.attackRadius);
    }
}
