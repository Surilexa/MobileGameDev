using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicController : MonoBehaviour
{
    [Header("Music")]
    public AudioSource DarkZoneAudio;
    public AudioSource mainMenuAudio;
    public AudioSource loseMenuAudio;
    public AudioSource winMenuAudio;
    public AudioSource castleAudio;
    public AudioSource beachAudio;

    public void playDarkZone()
    {
        DarkZoneAudio.Play();
    }
    public void stopDarkZone()
    {
        DarkZoneAudio.Stop();
    }
    public void playMainMenuAudio()
    {
        mainMenuAudio.Play();
    }
    public void stopMainMenuAudio()
    {
        mainMenuAudio.Stop();
    }
    public void playLoseMenuAudio()
    {
        loseMenuAudio.Play();
    }
    public void stopLoseMenuAudio()
    {
        loseMenuAudio.Stop();
    }
    public void playWinMenuAudio()
    {
        winMenuAudio.Play();
    }
    public void stopWinMenuAudio()
    {
        winMenuAudio.Stop();
    }
    public void stopCastleAudio()
    {
        castleAudio.Stop();
    }
    public void stopBeachAudio()
    {
        beachAudio.Stop();
    }
}
