using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NodeData
{
    public static List<NodeController> selectedNodes = new List<NodeController>();
    public static List<NodeController> activeNodes = new List<NodeController>();
    public static List<NodeController> deactiveNodes = new List<NodeController>();

    public static bool allowUnallocation = false;
}
