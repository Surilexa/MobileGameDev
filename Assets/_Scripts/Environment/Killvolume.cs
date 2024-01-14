using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killvolume : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "KillVolume")
        {
            Destroy(gameObject);
            Debug.Log("Kill");
        }
    }
}
