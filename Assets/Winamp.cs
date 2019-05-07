using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winamp : MonoBehaviour {

    public AudioClip[] clips;
    public AudioSource source;
    public void PlayClip(int i)
    {
        source.clip = clips[i];
        source.Play();
    }
}
