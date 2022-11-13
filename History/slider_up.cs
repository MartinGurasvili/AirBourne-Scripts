using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime ;

public class slider_up : MonoBehaviour
{
    public Slider red;
    public Slider  blue;

    void Update()
    {
        if( blue.value !=  (float)PhotonNetwork.CurrentRoom.CustomProperties["B1u3"])
        {
            blue.value=  (float)PhotonNetwork.CurrentRoom.CustomProperties["B1u3"];
        }
        if(red.value !=  (float)PhotonNetwork.CurrentRoom.CustomProperties["R33d"])
        {
            red.value =  (float)PhotonNetwork.CurrentRoom.CustomProperties["R33d"];
        }
        
        

    }


}
