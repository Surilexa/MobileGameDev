using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuState : GameBaseState
{
    public override void EnterState(GameStateManager game, GameController controller)
    {
        Debug.Log("MainMenuLoad");
        GameObject.Find("MusicController").GetComponent<musicController>().playMainMenuAudio();
        controller.LoadMainMenu();
    }

    public override void ExitState(GameStateManager game, GameController controller)
    {
        controller.deLoadMainMenu();
        controller.toSetupState = false;
        controller.toMenuState= false;
        GameObject.Find("MusicController").GetComponent<musicController>().stopMainMenuAudio();
    }

    public override void UpdateState(GameStateManager game, GameController controller)
    {
        if (controller.toSetupState == true)
        {
            game.LeaveState(game.menuState);
            game.SwitchState(game.setupState);
        }
    }
}
