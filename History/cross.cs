using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class cross : MonoBehaviour
{
    public Transform target;
    public Camera cam;

    public PhotonView PV;

    void FixedUpdate()
    {
        if(PV!=null)
        {
            if(!PV.IsMine)
            {
                Destroy(gameObject);
            }
            else{
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,cam.WorldToScreenPoint(target.position),Time.deltaTime *100);
            }
        }
        else
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,cam.WorldToScreenPoint(target.position),Time.deltaTime *100);
        }
        
        
    }
}
