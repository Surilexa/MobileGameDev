using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_DamagePopUp : MonoBehaviour
{
    
    public void showDamageDelt( Vector3 pos, float DamageAmount, bool crit)
    {   
        popupDamage.Create(pos, DamageAmount, crit);
    }
}   
