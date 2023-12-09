using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotsound : MonoBehaviour
{
 
    public AudioSource audioSource;

    public void playButton()
    {
        audioSource.Play();
    }
}

