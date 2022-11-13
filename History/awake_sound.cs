using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Photon.Pun;
public class awake_sound : MonoBehaviour
{
    PhotonView PV;
    AudioSource ad;
    void Start()
    {
        AudioSource ad = gameObject.GetComponent<AudioSource>();
        PV = gameObject.GetComponent<PhotonView>();
        PV.RPC("playyy",RpcTarget.All);
        ad.Play();
    }

    [PunRPC]
    public void playyy()
    {
        AudioSource ad = gameObject.GetComponent<AudioSource>();
        ad.Play();
    }
}
