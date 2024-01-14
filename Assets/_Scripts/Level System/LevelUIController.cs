using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelUIController : MonoBehaviour
{
    private static int level = 0;
    public static float EXP = 0;
    private static float EXPScaling = 25;

    private bool needEXP = false;

    [SerializeField] Image ExpBar;
    [SerializeField] Text levelDisplay;

    //scale the total exp needed to level up at a base rate of 10
    private static float TotalEXPForNextLevel = 100 + (level * EXPScaling);

    private float desiredEXP = 0;
    private float fillRate = 0;

    //adds exp on enemy killed
    private void Update()
    {
        addToBar();
    }
    public float changeExpForLevelUp()
    {
        return 100 + (level * 75);
    }
    public void addEXP(float experience)
    {
        EXP += experience;
        fillRate = (experience / 10) / 10;
        desiredEXP = (experience / TotalEXPForNextLevel) + ExpBar.fillAmount;
        Debug.Log(ExpBar.fillAmount);
        needEXP = true;
        E_StaticData.enemyLevel = getLevel();
    }

    //remove exp on death, not bellow 0 of current level
    public void removeEXP(int experience)
    {

    }
    public void setNewEXP()
    {
        TotalEXPForNextLevel = changeExpForLevelUp();
    }

    public static int getLevel()
    {
        return level;
    }
    public void changeLevel()
    {
        //change the text level
        levelDisplay.text = (level + 1).ToString();
        
        PlayerData.currentSkillPoints++;
        PlayerData.skillPointsDisplayed = PlayerData.currentSkillPoints;
        GameObject.Find("SkillPoints").GetComponent<Text>().text = PlayerData.skillPointsDisplayed.ToString();
    }
    public void addToBar()
    {
        if (needEXP && ExpBar.fillAmount <= desiredEXP)
        {
            ExpBar.fillAmount += fillRate * Time.deltaTime;
            if (ExpBar.fillAmount >= 1.0f)
            {
                ExpBar.fillAmount = 0f;
                desiredEXP -= 1.0f;
                level++;
                changeLevel();
                PlayerData.increaseBaseDamg();
                //changing the desired exp back to a whole number
                desiredEXP *= TotalEXPForNextLevel;
                setNewEXP();

                //after new exp total is calc'd, change desired back to %
                desiredEXP /= TotalEXPForNextLevel;
            }
        }
        else
        {
            needEXP= false;
            //Debug.Log(ExpBar.fillAmount);
        }
    }

}
