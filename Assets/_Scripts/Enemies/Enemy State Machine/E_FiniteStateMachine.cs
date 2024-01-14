using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_FiniteStateMachine
{
    public E_State currentState { get; private set; }

    public void Initialize(E_State startingState)
    {
        currentState= startingState;
        currentState.Enter();
    }

    public void ChangeState(E_State newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
}
