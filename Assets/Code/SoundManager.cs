using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource background;
    public AudioSource collect;
    public AudioSource ghost;
    public AudioSource goodGameOver;
    public AudioSource badGameOver;
    public AudioSource objectLost;
    public AudioSource hit;
    public AudioSource seen; 
    public bool isPlaying = true;
    public static SoundManager instance; 
    void Awake()
    {
        if (isPlaying && background!=null)
        {
            background.Play();
        }

        instance = this; 
    }

    public void playCollect()
    {
        if (isPlaying&& collect != null)
        {
            collect.Play();
        }
    }

    public void playGhost()
    {
        if(isPlaying && ghost != null)
        {
            ghost.Play();
        }
    }

    public void playGoodGameOver()
    {
        if (isPlaying && goodGameOver!= null)
        {
            goodGameOver.Play();
        }
    }

    public void playBadGameOver()
    {
        if (isPlaying && badGameOver != null)
        {
            badGameOver.Play();
        }
    }

    public void playItemLost()
    {
        if (isPlaying && objectLost != null)
        {
            objectLost.Play();
        }
    }

    public void playHit()
    {
        if (isPlaying && hit != null)
        {
            hit.Play();
        }
    }

    public void playSeen()
    {
        if(isPlaying && seen != null)
        {
            seen.Play(); 
        }
    }
}
