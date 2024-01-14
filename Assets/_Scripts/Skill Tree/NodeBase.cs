using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N_NodeBase
{
    protected string nodeName;
    protected N_Node node;
    protected bool isActive;
    public N_NodeBase(string nodeName, N_Node node, bool isActive)
    {
        this.nodeName = nodeName;
        this.node = node;
        this.isActive = isActive;
    }
}
