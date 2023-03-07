using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GamePlayState : GameBaseState//State
{

    private Transform playerSpawnLocation;
    private Transform enemy1SpawnLocation;

    public override void EnterState(GameStateManager game, GameController controller)
    {
        Debug.Log("State: Game Play");
        Debug.Log("Listen for Player inputs");
        Debug.Log("Display Player Hud");
        spawnPlayerUI(controller);
    }

    public override void UpdateState(GameStateManager game, GameController controller)
    {
        if(controller.killPlayer == true)
        {
            game.SwitchState(game.loseState);
        }
    }
    public void spawnPlayerUI(GameController controller)
    {
        //attach the input UI to the screen
        controller.LoadPlayerUI();
    }
    public override void ExitState(GameStateManager game, GameController controller)
    {
        controller.deLoadLevel();
    }

}
