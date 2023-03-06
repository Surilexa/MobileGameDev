using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_AnimationToStateMachine : MonoBehaviour
{
    public E_AttackState attackState;
    private void TriggerAttack()
    {
        attackState.TriggerAttack();
    }
    private void FinishAttack()
    {
        attackState.FinishAttack();
    }
}
