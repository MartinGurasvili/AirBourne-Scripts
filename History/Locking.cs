using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;
public class Locking: MonoBehaviour
{
    private bool x;
    private bool y =false;
    private float timer = 0f;
    void FixedUpdate()
        {
            timer += Time.deltaTime;
            if(gameObject.GetComponent<TMP_Text>().text == "Locked")
            {
                AudioSource ad = gameObject.GetComponent<AudioSource>();
                ad.loop = true;
                if(y ==false)
                {
                    ad.Play();
                }
                y = true;
                
                
            }
            else
            {
                if(timer >= 1f)
                {
                    
                    AudioSource ad = gameObject.GetComponent<AudioSource>();
                    ad.Play();
                    timer = 0f;
                    
                }
                y = false;
            }
            
            
        }
      
}
