using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class TestingScript : MonoBehaviour
{
    // Start is called before the first frame update

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            popupDamage.Create(UtilsClass.GetMouseWorldPosition(), 200, true);
        }
    }

}
