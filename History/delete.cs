using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delete : MonoBehaviour
{
    private float timer = 0 ;
    public float todelete;

    void Update()
    {
        timer += Time.deltaTime;

        if(timer > todelete)
        {
            Destroy(gameObject);
        }
    }
}
