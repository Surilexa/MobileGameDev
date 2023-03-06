using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newChargeStateData", menuName = "Data/State Data/Charge State")]
public class D_ChargeStateData : ScriptableObject
{
    public float chargeSpeed = 5f;

    public float chargeTime = 2f;
}
