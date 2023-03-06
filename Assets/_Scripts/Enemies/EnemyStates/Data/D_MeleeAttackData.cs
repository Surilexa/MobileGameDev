using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newMeleeAttackData", menuName = "Data/State Data/Melee Attack Data")]
public class D_MeleeAttackData : ScriptableObject
{
    public float attackRadius = 0.5f;

    public LayerMask whatIsPlayer;

    public float attackDamage = 1f;
}
