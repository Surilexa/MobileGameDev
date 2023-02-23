using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Lose State")]
    
    public AudioSource loseAudio;


    [Header("StateTransition")]
    public bool toPlayState = false;
    public bool toSetupState = false;

    [Header("Load Level 1")]
    public GameObject level1;


    [Header("Win State")]
    public AudioSource winAudio;


    [Header("UI")]

    public GameObject playerUI;
    public GameObject MainMenuUI;


    public string currentLevel;
    private void Awake()
    {
        level1.SetActive(false);
        playerUI.SetActive(false);
    }
    public void LoadLevel1()
    {
        level1.SetActive(true);
        currentLevel = level1.name;
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
}
