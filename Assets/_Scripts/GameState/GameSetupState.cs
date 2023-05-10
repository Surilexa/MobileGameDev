using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSetupState : GameBaseState//State
{
    private Vector2 screenBounds;

    public override void EnterState(GameStateManager game, GameController controller)
    {
        game.unpauseTheGame();
        Debug.Log("STATE: Game Setup");
        Debug.Log("Load Save Data");
        Debug.Log("Spawn Units");
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height, Camera.main.transform.position.z));
        BuildWorld(game, controller);
    }

    public override void UpdateState(GameStateManager game, GameController controller)
    {
        //Debug.Log(controller.toPlayState);
        if (controller.toPlayState == true)
        {
            game.LeaveState(game.setupState);
            game.SwitchState(game.playState);
        }
    }
    public void BuildWorld(GameStateManager game, GameController controller)
    {
        //call all the spawn/generate methods
        generateLevel(controller);
        controller.toPlayState = true;
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
