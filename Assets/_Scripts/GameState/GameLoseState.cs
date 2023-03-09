using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoseState : GameBaseState//State
{
    public bool lose;
    public override void EnterState(GameStateManager game, GameController controller)
    {
        GameObject.Find("MusicController").GetComponent<musicController>().stopDarkZone();
        GameObject.Find("MusicController").GetComponent<musicController>().stopCastleAudio();
        GameObject.Find("MusicController").GetComponent<musicController>().stopBeachAudio();
        GameObject.Find("MusicController").GetComponent<musicController>().playLoseMenuAudio();
        controller.showLoss();
        Debug.Log("State: LoseState");
        Debug.Log("Show lose Text");
        game.stopTheGame();
    }

    public override void ExitState(GameStateManager game, GameController controller)
    {
        controller.hideLoss(); 
        GameObject.Find("MusicController").GetComponent<musicController>().stopLoseMenuAudio();
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

