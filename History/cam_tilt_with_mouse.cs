using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam_tilt_with_mouse : MonoBehaviour
{
    public GameObject pivotpoint;
   
    void Update()
    {
        var mousePos = Input.mousePosition;
        mousePos.x -= Screen.width/2;
        mousePos.y -= Screen.height/2;  
        // Debug.Log(mousePos.x);
        if(mousePos.y < 0 )
        {
            if(gameObject.transform.rotation.x > -0.04f )
            {
                gameObject.transform.Rotate(new Vector3(mousePos.y,0,0),Time.deltaTime);
            }
        }
        else{
            if(gameObject.transform.rotation.x < 0.04f)
            {
                gameObject.transform.Rotate(new Vector3(mousePos.y,0,0),Time.deltaTime);
            }
        }
        if(mousePos.x > 0 )
        {
            if(pivotpoint.transform.rotation.y > -0.20f )
            {
                pivotpoint.transform.Rotate(new Vector3(0,-mousePos.x,0),Time.deltaTime/1.5f);
            }
        }
        else{
            if(pivotpoint.transform.rotation.y < 0.07f)
            {
                pivotpoint.transform.Rotate(new Vector3(0,-mousePos.x,0),Time.deltaTime/1.5f);
            }
        }

    }
}
