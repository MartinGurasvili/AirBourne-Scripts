using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
namespace UnityStandardAssets.Vehicles.Aeroplane{
public class missile : MonoBehaviour
{
    public Transform taget;
    public Rigidbody rig;

    public float turn = 400;
    public float spd = 200;

    private getinfo gi;
    private gunbang gu;

    public GameObject exp;

    private Quaternion targetrot;
    public PhotonView PV;
    private float timer =0;

    void Start() {
        PV = GetComponent<PhotonView>();
    }

    void FixedUpdate()
    {
        timer = Time.deltaTime *1;
        GameObject pl = GameObject.FindWithTag("Player");
        gu = pl.GetComponent<gunbang>();
        gi = pl.GetComponent<getinfo>();
        taget = gi.rayject;
        rig.velocity = transform.forward * spd;
        if(taget != null)
        {
            if(timer < 3f)
            {
                targetrot = Quaternion.LookRotation(taget.position - transform.position);
                rig.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetrot, turn));
            }
            
                
            
        }
    
    }

    void OnTriggerEnter(Collider col)
    {
        
        if (col.gameObject.tag == "carry")
        {
            GameObject a = PhotonNetwork.Instantiate("exp", Vector3.zero,Quaternion.identity);
            a.transform.position = gameObject.transform.position;
            
            enemy em = col.transform.GetComponent<enemy>();
            if(em!=null)
            {
                em.Takedam(10,gameObject.transform.parent.gameObject.GetComponent<PhotonView>().Owner.NickName);
                gu.hitmarkt();
            }
            
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "plane")
        {
            // Debug.Log("hitS");
            PV.RPC("mis_plane",RpcTarget.All);
            
        }

    }
    [PunRPC]
    void mis_plane()
    {
        // if(PV.IsMine)
        // {
        //     return;
        // }
        // Debug.Log("hit");
        GameObject a = PhotonNetwork.Instantiate("exp", Vector3.zero,Quaternion.identity);
        //GameObject a = Instantiate(exp);
        a.transform.position = gameObject.transform.position;
        
        uiplane ue = taget.GetComponent<uiplane>(); 
        GameObject pl = GameObject.FindWithTag("Player");
        gu = pl.GetComponent<gunbang>();
        if(ue!=null)
        {
            ue.takedam(25,gameObject.transform.parent.gameObject.GetComponent<PhotonView>().Owner.NickName);
            // ue.health -= 25;
            gu.hitmarkt();
        }
        Destroy(gameObject);
    }
}}
