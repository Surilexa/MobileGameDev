using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class E_MeleeAttackState : E_AttackState
{
    protected D_MeleeAttackData stateData;

    protected AttackDetails attackDetails;

    public E_MeleeAttackState(E_Entity entity, E_FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_MeleeAttackData stateData) : base(entity, stateMachine, animBoolName, attackPosition)
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

        attackDetails.damageAmount = stateData.attackDamage;
        attackDetails.position = entity.transform.position;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        Debug.Log("we triggered attack");
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attackPosition.position, stateData.attackRadius, stateData.whatIsPlayer);

        foreach (Collider2D collider in detectedObjects)
        {
            GameObject.Find("Player").GetComponent<PlayerController>().takeDamage();
            //Debug.Log("player took damage");
            // collider.transform.SendMessage("Damage", attackDetails);
        }
    }
}
