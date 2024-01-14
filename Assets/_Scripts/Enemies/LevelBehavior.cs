using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelBehavior : MonoBehaviour
{
    public int getDisplayLevel()
    {
        return int.Parse(this.GetComponent<Text>().text);
    }
    public void setDisplayLevel(int level)
    {
        this.GetComponent<Text>().text = level.ToString();
    }
}
