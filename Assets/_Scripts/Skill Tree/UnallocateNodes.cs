using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnallocateNodes : MonoBehaviour
{
    public void unallocateButtonPressed()
    {
        NodeData.allowUnallocation = !NodeData.allowUnallocation;
    }
}
