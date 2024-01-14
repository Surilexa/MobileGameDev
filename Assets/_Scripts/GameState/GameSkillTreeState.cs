using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSkillTreeState : GameBaseState
{
    public override void EnterState(GameStateManager game, GameController controller)
    {
        Debug.Log("to skill tree state");
        //pause game
        Time.timeScale= 0;
    }

    public override void ExitState(GameStateManager game, GameController controller)
    {
        //unpause game
        Debug.Log("unpause");
        Time.timeScale = 1;
    }
    public override void UpdateState(GameStateManager game, GameController controller)
    {
        if (controller.isSkillTree == false)
        {
            this.ExitState(game, controller);
            game.SwitchState(game.playState);
        }
    }
}
