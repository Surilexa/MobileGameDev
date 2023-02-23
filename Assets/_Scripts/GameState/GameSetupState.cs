using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private Vector2 screenBounds;

    
    
    public override void EnterState(GameStateManager game, GameController controller)
    {
        Debug.Log("STATE: Game Setup");
        Debug.Log("Load Save Data");
        Debug.Log("Spawn Units");
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height, Camera.main.transform.position.z));
        controller.toPlayState = true;
        BuildWorld(game, controller);
    }

    public override void UpdateState(GameStateManager game, GameController controller)
    {
        if(controller.toPlayState == true)
        {
            game.LeaveState(game.setupState);
            game.SwitchState(game.playState);
        }
    }
    public void BuildWorld(GameStateManager game, GameController controller)
    {
        //call all the spawn/generate methods
        generateLevel(controller);

    }
    public void generateLevel(GameController controller)
    {
        //spawn envirnonment prefab with level name
        controller.LoadLevel1();
    }

    public override void ExitState(GameStateManager game, GameController controller)
    {
        controller.toPlayState = false;
    }
}
