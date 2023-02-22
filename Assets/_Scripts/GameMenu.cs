using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    GameStateManager gameManager;
    private void Awake()
    {
        gameManager= GetComponent<GameStateManager>();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        gameManager.toPlayState = true;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
