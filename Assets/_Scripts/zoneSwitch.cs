using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoneSwitch : MonoBehaviour
{
    public AudioSource stopMusic;
    public AudioSource startMusic;
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit");
        if (other.gameObject == player)
        {

            if (!startMusic.isPlaying)
            {
                startMusic.Play();
            }
            stopMusic.Stop();
        }
    }
}
