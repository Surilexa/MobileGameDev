using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetupState : GameBaseState//State
{
    /*private GameFSM _stateMachine;
    private GameController _controller;

    public GameSetupState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        Debug.Log("STATE: Game Setup");
        Debug.Log("Load Save Data");
        Debug.Log("Spawn Units");

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
        // _stateMachine.ChangeState(_stateMachine.GamePlayState);
    }*/
    
    
    public override void EnterState(GameStateManager game)
    {
        Debug.Log("STATE: Game Setup");
        Debug.Log("Load Save Data");
        Debug.Log("Spawn Units");
        BuildWorld();
    }

    public override void UpdateState(GameStateManager game)
    {
        if(game.toPlayState == true)
        {
            game.SwitchState(game.playState);
        }
    }
    public void BuildWorld()
    {
        //call all the spawn/generate methods
        spawnPlayer();
        generateLevel("level_1");
    }

    public void spawnPlayer()
    {
        //spawn player prefab
    }
    public void generateLevel(string level)
    {
        //spawn envirnonment prefab with level name

    }
    public void spawnUI()
    {
        //attach the input UI to the screen

    }
}
