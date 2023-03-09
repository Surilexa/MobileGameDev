using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWinState : GameBaseState    // State
{
    
    public override void EnterState(GameStateManager game, GameController controller)
    {
        GameObject.Find("MusicController").GetComponent<musicController>().stopCastleAudio();
        GameObject.Find("MusicController").GetComponent<musicController>().playWinMenuAudio();

        controller.showWin();
        Debug.Log("State: WinState");
        Debug.Log("Show win Text");
        game.stopTheGame();
    }

    public override void UpdateState(GameStateManager game, GameController controller)
    {
        if (controller.toMenuState == true)
        {
            ExitState(game, controller);
            game.SwitchState(game.menuState);
        }
    }
    public override void ExitState(GameStateManager game, GameController controller)
    {
        controller.hideWin();
        GameObject.Find("MusicController").GetComponent<musicController>().stopWinMenuAudio();
    }

}
