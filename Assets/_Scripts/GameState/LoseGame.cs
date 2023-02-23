using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Events;
using Unity.VisualScripting;

public class LoseGame : MonoBehaviour
{
    private GameController controller;
    private GameStateManager stateManager;

    private void Awake()
    {
        controller = GameObject.Find("GameStateManager").GetComponent<GameController>();
        stateManager= GameObject.Find("GameStateManager").GetComponent<GameStateManager>();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            stateManager.SwitchState(stateManager.loseState);
        }
    }
    public void mainMenu()
    {
        stateManager.SwitchState(stateManager.menuState);
        controller.deactivateEverything();
    }

}
