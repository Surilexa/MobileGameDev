using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == GameObject.Find("Player"))
        {
            GameObject.Find("Player").GetComponent<PlayerController>().healPlayer();

            //gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
