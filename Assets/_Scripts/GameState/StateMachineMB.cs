using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StateMachineMB : MonoBehaviour
{
    public State CurrentState { get; private set; }
    public State _previousState;

    private bool _inTransition = false;

    public void ChangeState(State newState)
    {
        // ensure we're ready for a new state
        if (CurrentState == newState || _inTransition)
            return;

        ChangeStateSequence(newState);
    }
    private void ChangeStateSequence(State newState)
    {
        _inTransition = true;

        CurrentState?.Exit();
        StoreStateAsPrevious(CurrentState, newState);

        CurrentState = newState;

        CurrentState?.Exit();
        _inTransition = false;
    }
    private void StoreStateAsPrevious(State currentState, State newState)
    {
        if (_previousState == null && newState != null)
            _previousState = newState;

        else if (_previousState != null && CurrentState != null)
        {
            _previousState = CurrentState;
        }

    }
    public void ChangeStatetoPrevious()
    {
        if (_previousState != null)
        {
            ChangeState(_previousState);
        }
        else
        {
            Debug.LogWarning("There is no previous state to change to");
        }
    }

    // pass down Update ticks to States, since they won't have a MonoBehaviour
    protected virtual void Update()
    {
        // simulate update ticks in states
        if (CurrentState != null && !_inTransition)
            CurrentState.Tick();
    }

    protected virtual void FixedUpdate()
    {
        // simulate fixedUpdate ticks in states
        if (CurrentState != null && !_inTransition)
            CurrentState.FixedTick();
    }
    protected virtual void OnDestroy()
    {
        CurrentState?.Exit();
    }

    /*public void RevertState()
    {
        if (_previousState != null)
            ChangeState(_previousState);
    }*/



    /*void ChangeStateRoutine(IState newState)
    {
        _inTransition = true;
        // begin our exit sequence, to prepare for new state
        if (CurrentState != null)
            CurrentState.Exit();
        // save our current state, in case we want to return to it
        if (_previousState != null)
            _previousState = CurrentState;

        CurrentState = newState;

        // begin our new Enter sequence
        if (CurrentState != null)
            CurrentState.Enter();

        _inTransition = false;
    }*/

}