using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class randomsound : MonoBehaviour
{
    public AudioClip[] sfx;
    public int rand;
    void Start()
    {
        AudioSource ad = GetComponent<AudioSource>();
        rand = Random.Range(0, sfx.Length);
        ad.clip = sfx[rand];
        ad.Play();

    }


}
