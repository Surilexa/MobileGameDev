using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameController))]
public class GameFSM : StateMachineMB
{
   /* private GameController _controller;

    public GameSetupState SetupState { get; private set; }
    public GamePlayState GamePlayState { get; private set; }
    public LoseState LoseState { get; private set; }
    public WinState WinState { get; private set; }

    private void Awake()
    {
        _controller = GetComponent<GameController>();

        SetupState = new GameSetupState(this, _controller);
        GamePlayState = new GamePlayState(this, _controller);
        LoseState = new LoseState(this, _controller);
        WinState = new WinState(this, _controller);
    }

    private void Start()
    {
        ChangeState(SetupState);
    }*/
}
