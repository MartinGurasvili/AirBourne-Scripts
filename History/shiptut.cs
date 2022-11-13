using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shiptut : MonoBehaviour
{
    public GameObject [] fires ;
    public GameObject [] turrents;

    public enemytut em;
    
    public enemytut [] turretem;
    void Update()
    {
        if(em.health < 85)
        {
            fires[0].SetActive(true);
        }
        if(em.health < 75)
        {
            fires[1].SetActive(true);
        }
        if(em.health < 50)
        {
            fires[2].SetActive(true);
            turrents[0].SetActive(false);
            turretem[0].health = 0;
        }
        if(em.health < 20)
        {
            fires[3].SetActive(true);
            turrents[1].SetActive(false);
            turretem[1].health = 0;
        }
    }
}
