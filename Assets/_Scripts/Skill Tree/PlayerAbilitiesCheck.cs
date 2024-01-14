using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilitiesCheck : MonoBehaviour
{
    //this script will run through the active node array and make changes depending on which nodes are activated
    public void ActivateNodeAbilities()
    {
        List<NodeController> activeList = NodeData.activeNodes;
        List<NodeController> deactiveList = NodeData.deactiveNodes;
        for (int i = 0;i < activeList.Count; i++)
        {
            if (activeList[i] != null)
            {
                //enable the skill related to the name of the node
                GameObject.Find("Player").GetComponent<PlayerController>().enableSkills(activeList[i].getName());
            }
        }
        /*for (int x = 0; x < deactiveList.Count; x++)
        {
            if (deactiveList[x] != null)
            {
                GameObject.Find("Player").GetComponent<PlayerController>().disableSkills(deactiveList[x].getName());
            }
        }

        deactiveList.Clear();
        NodeData.deactiveNodes.Clear();
        */
    }
}
