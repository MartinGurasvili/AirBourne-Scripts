using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tut_inst : MonoBehaviour
{
    public GameObject [] planes;
    private int index;

    
    
    void Start()
    {

        instantspawn();
        
    }

    public void instantspawn()
    {
        index=PlayerPrefs.GetInt("planeindex", 0);
        planes[index].SetActive(true);
    }
}
