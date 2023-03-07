using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("Lose State")]
    
    //public AudioClip loseAudio;
    public bool toMenuState = false;
    public AudioSource LoseSound;

    [Header("StateTransition")]
    public bool toPlayState = false;
    public bool toSetupState = false;

    [Header("Load Level 1")]
    public GameObject level1;


    [Header("Win State")]
    //public AudioClip winAudio;
    public GameObject WinUI;


    [Header("UI")]

    public AudioSource WinSound;
    public GameObject playerUI;
    public GameObject MainMenuUI;
    public GameObject loseUI;

    [Header("Player")]
    public bool killPlayer = false;
    public GameObject player;


    [Header("Respawn Points")]
    public GameObject playerRespawn;
    public GameObject enemy1Respawn;


    public string currentLevel;
    private void Awake()
    {
        deactivateEverything();
        AudioSource WinSound = new AudioSource();
        AudioSource LoseSound = new AudioSource();
    }
    public void LoadLevel1()
    {
        level1.SetActive(true);
        player.SetActive(true);
        //currentLevel = level1.name;
    }
    public void LoadPlayerUI()
    {
        playerUI.SetActive(true);
    }
    public void LoadMainMenu()
    {
        MainMenuUI.SetActive(true);
    }
    public void deLoadMainMenu()
    {
        MainMenuUI.SetActive(false);
    }
    public void deLoadLevel()
    {
        GameObject.Find(currentLevel).gameObject.SetActive(false);
    }
    public void showLoss()
    {
        loseUI.SetActive(true); 
    }
    public void hideLoss()
    {
        loseUI.SetActive(false);
    }
    public void showWin()
    {
        WinUI.SetActive(true);
    }
    public void hideWin()
    {
        WinUI.SetActive(false);
    }
    public void mainMenuState()
    {
        toMenuState = true;
    }
    public void KillPlayer()
    {
        killPlayer = true;
    }

    public void StartGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        toSetupState = true;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    public void deactivateEverything()
    {
        level1.SetActive(false);
        playerUI.SetActive(false);
        loseUI.SetActive(false);
        WinUI.SetActive(false);
        player.SetActive(false);
    }
    public void reloadLevel()
    {
        SceneManager.LoadScene(0);
    }
}
