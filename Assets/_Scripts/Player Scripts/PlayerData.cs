using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public static class PlayerData
{
    public static float playerDamage = 0;

    public static float baseCritChance = 15;

    public static float baseCritDamage = .5f;

    public static float baseMovementSpeed = 100f;

    public static bool didCrit = false;

    public static float dashDistance = 4f;

    public static float playerBaseDamage = (5 * (LevelUIController.getLevel() + 1));
    public static float areaSlashBaseDamage = (9 * (LevelUIController.getLevel() + 1));
    public static float slashBaseDamage = (8 * (LevelUIController.getLevel() + 1));
    public static float tripleSlashBaseDamage = (14 * (LevelUIController.getLevel() +1));


    public static int skillPointsDisplayed = 0;
    public static int currentSkillPoints = 0;

    private static int slashCount = 0;
    public static float CalculatePlayerDamage(string skillUsed)
    {
        
        if(skillUsed == "basicAttack")
        {
            playerDamage = playerBaseDamage;

            if (Random.Range(1, 100) <= (baseCritChance + SkillUnlockData.addedCritChance))
            {
                playerDamage *= 1 + (baseCritDamage + SkillUnlockData.addedCritDamage);
                
                didCrit= true;
            }
            else
            {
                didCrit= false;
            }
        }
        else if (skillUsed == "slashAttack")
        {
            playerDamage = slashBaseDamage;

            if (Random.Range(1, 100) <= (baseCritChance + SkillUnlockData.addedCritChance))
            {
                playerDamage *= 1 + (baseCritDamage + SkillUnlockData.addedCritDamage);

                didCrit = true;
            }
            else
            {
                didCrit = false;
            }
        }
        else if (skillUsed == "AreaSlash")
        {
            playerDamage = areaSlashBaseDamage;

            if (Random.Range(1, 100) <= (baseCritChance + SkillUnlockData.addedCritChance))
            {
                playerDamage *= 1 + (baseCritDamage + SkillUnlockData.addedCritDamage);

                didCrit = true;
            }
            else
            {
                didCrit = false;
            }
        }
        else if (skillUsed == "TripleSlash")
        {
            slashCount++;
            if(slashCount == 3) {
                slashCount = 0;
                playerDamage = tripleSlashBaseDamage * 3;
                if (Random.Range(1, 100) <= (baseCritChance + 30))
                {
                    playerDamage *= 1 + (baseCritDamage + (float).3);

                    didCrit = true;
                }
                else
                {
                    didCrit = false;
                }
            }
            else
            {
                playerDamage = tripleSlashBaseDamage;
                if (Random.Range(1, 100) <= (baseCritChance + 30))
                {
                    playerDamage *= 1 + (baseCritDamage);

                    didCrit = true;
                }
                else
                {
                    didCrit = false;
                }
            }
            
        }
        //get a reference to the array of nodes that are modifiying the character
        //playerDamage = playerBaseDamage; //add skill tree mods here
        //Debug.Log(playerDamage);
        return playerDamage;
    }

    public static void increaseBaseDamg()
    {
        playerBaseDamage = (5 * (LevelUIController.getLevel() + 1));
        areaSlashBaseDamage = (9 * (LevelUIController.getLevel() + 1));
        slashBaseDamage = (8 * (LevelUIController.getLevel() + 1));
        tripleSlashBaseDamage = (14 * (LevelUIController.getLevel() +1));
    }
    public static int getPlayerLevel()
    {
        return LevelUIController.getLevel();
    }
}
