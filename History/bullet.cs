using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
namespace UnityStandardAssets.Vehicles.Aeroplane{
public class bullet : MonoBehaviour
{
    public float speed;
    public Rigidbody rig;

    private gunbang gu;
    public GameObject impactefx;
    public PhotonView PV;

    public GameObject hitobj;

    void Start() {
        PV = GetComponent<PhotonView>();
    }
    void Update()
    {
        GameObject pl = GameObject.FindWithTag("Player");
        gu = pl.GetComponent<gunbang>();

        rig.velocity = transform.forward * speed;
        
    }
    void OnTriggerEnter(Collider col)
    {
    
        if (col.gameObject.tag == "carry")
        {
            enemy em = col.transform.GetComponent<enemy>();
            if(em!=null)
            {
                em.Takedam(1,gameObject.transform.parent.gameObject.GetComponent<PhotonView>().Owner.NickName);
                gu.hitmarkt();
            }
           
            Destroy(gameObject);
        }
        // if (col.gameObject.tag == "plane")
        // {
        //     enemy em = col.transform.GetComponent<enemy>();
        //     if(em!=null)
        //     {
        //         em.health -= 2;
        //         gu.hitmarkt();
        //     }
        //     Destroy(gameObject);
        // }
        if (col.gameObject.tag == "plane")
        {
            hitobj = col.gameObject;
            PV.RPC("hit_plane",RpcTarget.All);
            // GameObject spark = Instantiate(impactefx, col.gameObject.transform);
            // spark.transform.parent = hitobj.transform;

        }
        
        

    }
    [PunRPC]
    void hit_plane()
    {
        // Debug.Log("hit plane");
        if(hitobj == null || hitobj.tag =="Player" )
        {
            return;
        }
        // Debug.Log("hit plane");
        uiplane ue = hitobj.GetComponent<uiplane>(); 

        GameObject pl = GameObject.FindWithTag("Player");
        gu = pl.GetComponent<gunbang>();
        if(ue!=null)
        {
            ue.takedam(2,gameObject.transform.parent.gameObject.GetComponent<PhotonView>().Owner.NickName);
            // ue.health -= 2;
            gu.hitmarkt();
        }
        
        Destroy(gameObject);
    }
}}
