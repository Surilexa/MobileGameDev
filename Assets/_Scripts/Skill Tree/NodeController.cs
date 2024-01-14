using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeController : MonoBehaviour
{
    [SerializeField] int skillPointCost;
    [SerializeField] string skillName;
    
    
    public bool isActivated = false;
    public bool isSelected = false;

    
    private NodeController node;
    public GameObject nodeBorder;
    public GameObject connectingLine;
    public NodeController previousNode;
    public NodeController nextNode;

    private bool allowActivation;


    [SerializeField] bool firstNode;
    [SerializeField] bool lastNode;

    
    
    private void Start()
    {
        node = this.gameObject.GetComponent<NodeController>();
    }

    public void onButtonClick()
    {
        //if the previous node is selected or active or null
        if(firstNode || NodeData.selectedNodes.Contains(previousNode) || NodeData.activeNodes.Contains(previousNode)) 
        {
            allowActivation = true;
            Debug.Log("is selected or active or previous is null");
        }
        else
        {
            allowActivation = false;
            Debug.Log("cannot activate");
        }
        if (isSelected)
        {
            //stop being selected if the node is the last in the branch
            if (lastNode)
            {
                isSelected = false;
                nodeBorder.GetComponent<Image>().color = Color.white;
                connectingLine.GetComponent<Image>().color = Color.white;
                NodeData.selectedNodes.Remove(node);

                PlayerData.skillPointsDisplayed += skillPointCost;
                GameObject.Find("SkillPoints").GetComponent<Text>().text = PlayerData.skillPointsDisplayed.ToString();
            }

            //if the node is not the final node and the next node
            else if(lastNode == false && nextNode.getSelected() == false)
            {
                isSelected = false;
                nodeBorder.GetComponent<Image>().color = Color.white;
                connectingLine.GetComponent<Image>().color = Color.white;
                NodeData.selectedNodes.Remove(node);

                PlayerData.skillPointsDisplayed += skillPointCost;
                GameObject.Find("SkillPoints").GetComponent<Text>().text = PlayerData.skillPointsDisplayed.ToString();
            }

            Debug.Log("unselect");
            /*for (int i = 0; i < NodeData.selectedNodes.Count; i++)
             {
                 if(GameObject.Find(skillName) == (Object)NodeData.selectedNodes[i])
                 {
                     NodeData.selectedNodes.RemoveAt(i);
                 }
             }
            */
        }
        //if the player can afford the skill
        else if (PlayerData.skillPointsDisplayed >= skillPointCost && allowActivation && node.getActivated() == false)
        {
            //allow the node to be selected
            isSelected = true;
            nodeBorder.GetComponent<Image>().color = Color.yellow;
            connectingLine.GetComponent<Image>().color = Color.yellow;
            NodeData.selectedNodes.Add(GameObject.Find(skillName).GetComponent<NodeController>());
            PlayerData.skillPointsDisplayed -= skillPointCost;
            GameObject.Find("SkillPoints").GetComponent<Text>().text = PlayerData.skillPointsDisplayed.ToString();
            printSelected();
        }
        //if the node is active and the player is allowed to unallocate that node
        else if(isActivated && NodeData.allowUnallocation) 
        {
            node.setActivated(false);
            nodeBorder.GetComponent<Image>().color = Color.white;
            connectingLine.GetComponent<Image>().color = Color.white;
            NodeData.activeNodes.Remove(node);

            PlayerData.skillPointsDisplayed += skillPointCost;
            GameObject.Find("SkillPoints").GetComponent<Text>().text = PlayerData.skillPointsDisplayed.ToString();

            GameObject.Find("Player").GetComponent<PlayerController>().disableSkills(getName());
        }
        else if (PlayerData.skillPointsDisplayed < 1)
        {
            Debug.Log("Not Enough Skill Points");
        }
    }
    public bool getSelected()
    {
        return isSelected;
    }
    public void setSelected(bool value)
    {
        isSelected = value;
    }
    public bool getActivated()
    {
        return isActivated;
    }
    public void setActivated(bool value)
    {
        isActivated = value;
    }
    public void changeToPurchased()
    {
        nodeBorder.GetComponent<Image>().color = Color.red;
        connectingLine.GetComponent<Image>().color = Color.red;

        node.setSelected(false);
        node.setActivated(true);
    }
    public string getName()
    {
        return name;
    }

    public void printSelected()
    {
        for(int i = 0; i < NodeData.selectedNodes.Count; i++)
        {
            Debug.Log(NodeData.selectedNodes[i]);
        }
    }
    public void printActivated()
    {
        for (int i = 0; i < NodeData.activeNodes.Count; i++)
        {
            Debug.Log(NodeData.activeNodes[i]);
        }
    }
}
