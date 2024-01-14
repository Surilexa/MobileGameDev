using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipDisplay : MonoBehaviour
{
    private void Update()
    {
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, this.transform.parent.rotation.y * -1.0f);
    }
}
