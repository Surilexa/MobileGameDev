using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    GameBaseState currentState;
    public MainMenuState menuState = new MainMenuState();
    public GameSetupState setupState = new GameSetupState();
    public GamePlayState playState= new GamePlayState();
    public GameLoseState loseState= new GameLoseState();
    public GameWinState winState= new GameWinState();

    private GameController gameController;
    void Start()
    {
        gameController = this.GetComponent<GameController>();
        currentState = menuState;

        currentState.EnterState(this, gameController);
    }
    void Update()
    {
        currentState.UpdateState(this, gameController);
    }
    public void SwitchState(GameBaseState state)
    {
        currentState = state;
        state.EnterState(this, gameController);
    }
    public void LeaveState(GameBaseState state)
    {
        state.ExitState(this, gameController);
    }
    public void stopTheGame()
    {
        Time.timeScale= 0;
    }
    public void unpauseTheGame()
    {
        Time.timeScale = 1.0f;
    }
}
