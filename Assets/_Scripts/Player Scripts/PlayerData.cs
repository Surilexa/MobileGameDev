using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public static class PlayerData
{
    public static float playerBaseDamage = (10 * (LevelUIController.getLevel() + 1));

    public static float playerDamage = 0;

    public static float CalculatePlayerDamage()
    {
        //get a reference to the array of nodes that are modifiying the character
        playerDamage = playerBaseDamage; //add skill tree mods here

        return playerDamage;
    }
}
