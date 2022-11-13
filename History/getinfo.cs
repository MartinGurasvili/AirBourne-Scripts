using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class getinfo : MonoBehaviour
{
    public GameObject crosshair;

    public GameObject panel;
    public Slider health;
    public TMP_Text healthtxt;

    public Transform rayject;

    private bool taget = false;


    void FixedUpdate()
    {
        
        RaycastHit hit;
        if (Physics.Raycast(crosshair.transform.position, crosshair.transform.forward, out hit))
        {
            if (hit.transform.tag == "carry" || hit.transform.tag == "plane")
            {
                rayject = hit.transform;

            }
            
        }
        
        if(rayject != null)
        {
            
            panel.SetActive(true);
            taget = true;
        
            if(taget == true)
            {
                //Waypoint_Indicator way = rayject.GetComponentInChildren<Waypoint_Indicator>();
                if(rayject.tag == "plane")
                {
                    uiplane ue = rayject.GetComponent<uiplane>(); 
                    if(ue != null)
                    {
                        health.value = ue.health;
                        healthtxt.text = ue.health.ToString()+"%";
                    }
                    else{
                        enemy em = rayject.GetComponent<enemy>();
                        health.value = em.health;
                        healthtxt.text = em.health.ToString()+"%";
                    }
                    
                    //way.enableSprite = true;
                }
                else{
                    enemy em = rayject.GetComponent<enemy>();
                    
                    if(em != null)
                    {
                        health.value = em.health;
                        healthtxt.text = em.health.ToString()+"%";
                        //way.enableSprite = true;
                    }
                    else
                    {
                        panel.SetActive(false);
                        taget = false;
                        //way.enableSprite = false;
                    }
                }
                

                
            }
            if(Vector3.Distance(rayject.position, transform.position) > 1000)
            {
                taget = false;
                panel.SetActive(false);
                //Waypoint_Indicator way = rayject.GetComponentInChildren<Waypoint_Indicator>();
                //way.enableSprite = false;
            }
            

        }
        else
        {
            panel.SetActive(false);
        }
        
        
        

    }

}
