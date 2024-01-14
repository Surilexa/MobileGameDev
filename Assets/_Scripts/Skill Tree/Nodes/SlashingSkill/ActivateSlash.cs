using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSlash : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        if(this.GetComponent<NodeController>().getActivated())
        {
            SkillUnlockData.slashSkillUnlock = true;
        }
        else
        {
            SkillUnlockData.slashSkillUnlock = false;
        }

    }
}
