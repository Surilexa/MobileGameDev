using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWinState : GameBaseState    // State
{
    /*private GameFSM _stateMachine;
    private GameController _controller;
    public WinState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        Debug.Log("State: WinState");
        Debug.Log("Show win Text");
        
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
    }
    */
    public override void EnterState(GameStateManager game)
    {
        Debug.Log("State: WinState");
        Debug.Log("Show win Text");
        
        game.winAudio.Play();
    }

    public override void UpdateState(GameStateManager game)
    {
        
    }
    public override void OnCollisionEnter(GameStateManager game)
    {
        base.OnCollisionEnter(game);
    }
}
