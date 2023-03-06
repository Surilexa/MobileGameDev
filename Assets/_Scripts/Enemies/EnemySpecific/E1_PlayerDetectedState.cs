using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_PlayerDetectedState : E_PlayerDetectedState
{
    private enemy1 enemy;
    public E1_PlayerDetectedState(E_Entity etity, E_FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetected stateData, enemy1 enemy) : base(etity, stateMachine, animBoolName, stateData)
    {
        this.enemy= enemy;
    }


}
