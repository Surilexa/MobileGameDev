using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoseState : GameBaseState//State
{
    /*private GameFSM _stateMachine;
    private GameController _controller;
    public LoseState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        Debug.Log("State: LoseState");
        Debug.Log("Show lose Text");

        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FixedTick()
    {
        base.FixedTick();
    }

    public override void Tick()
    {
        base.Tick();
    }*/
    public override void EnterState(GameStateManager game, GameController controller)
    {
        controller.loseAudio.Play();
        Debug.Log("State: LoseState");
        Debug.Log("Show lose Text");
    }

    public override void OnCollisionEnter(GameStateManager game, GameController controller)
    {
        
    }

    public override void UpdateState(GameStateManager game, GameController controller)
    {

    }
}

