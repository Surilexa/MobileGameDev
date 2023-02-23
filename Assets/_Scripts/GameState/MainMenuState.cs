using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Animations;
using UnityEngine;

public class MainMenuState : GameBaseState
{
    public override void EnterState(GameStateManager game, GameController controller)
    {
        Debug.Log("MainMenuLoad");

        controller.LoadMainMenu();
    }

    public override void ExitState(GameStateManager game, GameController controller)
    {
        controller.deLoadMainMenu();
        controller.toSetupState = false;
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
