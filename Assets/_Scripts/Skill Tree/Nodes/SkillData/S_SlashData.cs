using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "newSkillData", menuName = "Data/Skill Data/Slash Skill")]
public class S_SlashData : ScriptableObject
{
    public float slashDamage = 0f;

    public float slashCooldown = 5f;
}
