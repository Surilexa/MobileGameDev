using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    GameStateManager gameManager;
    GameController gameController;
    private void Awake()
    {
        gameManager= GetComponent<GameStateManager>();
        gameController= GetComponent<GameController>();
    }
    public void StartGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        gameController.toSetupState = true;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
