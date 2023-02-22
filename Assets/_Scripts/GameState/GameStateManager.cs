using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    GameBaseState currentState;
    public GameSetupState setupState = new GameSetupState();
    public GamePlayState playState= new GamePlayState();
    public GameLoseState loseState= new GameLoseState();
    public GameWinState winState= new GameWinState();

    public AudioSource winAudio;
    public AudioSource loseAudio;

    public bool toPlayState = false;

    void Start()
    {
        currentState = setupState;

        currentState.EnterState(this);
    }
    void Update()
    {
        currentState.UpdateState(this);
    }
    public void SwitchState(GameBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
