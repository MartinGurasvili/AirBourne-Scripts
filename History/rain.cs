using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rain : MonoBehaviour
{
    void Update()
    {
        if(GameObject.FindWithTag("MainCamera") !=null)
        {
            gameObject.transform.position = GameObject.FindWithTag("MainCamera").transform.position;
        }
    }
}
