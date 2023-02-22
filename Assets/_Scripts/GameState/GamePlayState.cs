using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GamePlayState : GameBaseState//State
{
    /*private GameFSM _stateMachine;
    private GameController _controller;

    public GamePlayState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }
    public override void Enter()
    {
        Debug.Log("State: Game Play");
        Debug.Log("Listen for Player inputs");
        Debug.Log("Display Player Hud");
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
        Debug.Log("Checking for win con");
        Debug.Log("Checking for lose con");
    }*/
    public override void EnterState(GameStateManager game)
    {
        Debug.Log("State: Game Play");
        Debug.Log("Listen for Player inputs");
        Debug.Log("Display Player Hud");
    }

    public override void UpdateState(GameStateManager game)
    {
        
    }
}
