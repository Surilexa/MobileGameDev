using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : GameBaseState
{
    public override void EnterState(GameStateManager game, GameController controller)
    {
        Debug.Log("Arrived in the respawn state");

    }

    public override void ExitState(GameStateManager game, GameController controller)
    {
        base.ExitState(game, controller);
    }

    public override void UpdateState(GameStateManager game, GameController controller)
    {
       
    }
}
