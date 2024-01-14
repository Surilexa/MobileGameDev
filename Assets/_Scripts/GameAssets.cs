using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets instance;


    public static GameAssets I
    {
        get
        {
            if(instance == null) instance = Instantiate(Resources.Load<GameAssets>("GameAssets"));
            return instance;
            
        }
    }

    public Transform pfDamagePopup;
}
