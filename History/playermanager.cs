using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class playermanager : MonoBehaviour
{
    PhotonView PV;
    // Start is called before the first frame update
    void Awake() {
       PV = GetComponent<PhotonView>();
    }
    void Start()
    {
        if(PV.IsMine)
        {
            create_controller();
        }
    }

    
    public void create_controller()
    {
       Debug.Log("hello");
       PhotonNetwork.Instantiate(Path.Combine("Playerman","Player"),Vector3.zero,Quaternion.identity);
    }
}
