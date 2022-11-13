using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ship : MonoBehaviour
{
    public GameObject [] fires ;
    public GameObject [] turrents;

    public enemy em;
    
    public enemy [] turretem;
    PhotonView PV;
    void Start() {
        PV = gameObject.GetComponent<PhotonView>();
    }
    void Update()
    {
        if(em.health < 70)
        {
            PV.RPC("set1",RpcTarget.All);
        }
        if(em.health < 50)
        {
            PV.RPC("set2",RpcTarget.All);
        }
        if(em.health < 30)
        {
            PV.RPC("set3",RpcTarget.All);
        }
        if(em.health < 10)
        {
            PV.RPC("set4",RpcTarget.All);
        }
    }
    [PunRPC]
    void set1()
    {
        fires[0].SetActive(true);
    }
    [PunRPC]
    void set2()
    {
        fires[1].SetActive(true);
    }
    [PunRPC]
    void set3()
    {
        fires[2].SetActive(true);
        turrents[0].SetActive(false);
        turretem[0].health = 0;
    }
    [PunRPC]
    void set4()
    {
        fires[3].SetActive(true);
        turrents[1].SetActive(false);
        turretem[1].health = 0;
    }
}
