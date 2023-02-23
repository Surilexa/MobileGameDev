using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoseState : GameBaseState//State
{
    public override void EnterState(GameStateManager game, GameController controller)
    {
        controller.LoseSound.Play();
        controller.showLoss();
        Debug.Log("State: LoseState");
        Debug.Log("Show lose Text");
        game.stopTheGame();
    }

    public override void ExitState(GameStateManager game, GameController controller)
    {
        controller.hideLoss();
    }

    public override void UpdateState(GameStateManager game, GameController controller)
    {
        if(controller.toMenuState == true)
        {
            ExitState(game, controller);
            game.SwitchState(game.menuState);

        }
    }

}

