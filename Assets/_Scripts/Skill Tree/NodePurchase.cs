using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodePurchase : MonoBehaviour
{
    private GameObject node;
    public void purchaseSelectedNodes()
    {
        int i;
        if (NodeData.selectedNodes.Count > 0)
        {
            //copy selected nodes to active nodes
            i = NodeData.activeNodes.Count;
            //Debug.Log(NodeData.activeNodes.Count);
            while (i < NodeData.selectedNodes.Count + NodeData.activeNodes.Count)
            {
                //Debug.Log(i);
                //Debug.Log(NodeData.selectedNodes.Count + NodeData.activeNodes.Count);
                Debug.Log("purchased");
                //Debug.Log(i);
                NodeData.activeNodes.Add(NodeData.selectedNodes[0]);
                node = GameObject.Find(NodeData.selectedNodes[0].getName());
                NodeData.selectedNodes.RemoveAt(0);
                node.GetComponent<NodeController>().changeToPurchased();
                i++;

            }
            node.GetComponent<NodeController>().printActivated();
            PlayerData.currentSkillPoints = PlayerData.skillPointsDisplayed;
            NodeData.selectedNodes.Clear();

            
        }
        

    }
}
