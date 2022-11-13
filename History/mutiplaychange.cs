using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
public class mutiplaychange : MonoBehaviour
{
    public GameObject canvas;
    public GameObject cam;
    public Rigidbody rb;
    public PhotonView PV;
    public Waypoint_Indicator wi;


    public BoxCollider bc;
    

    public plane_inst pl;
    public getinfo gi;
    public AeroplaneController ac;
    public AeroplaneUserControl2Axis au;
    public AeroplaneControlSurfaceAnimator aco;
    public AeroplaneAudio aa;
    public gunbang gb;

    // public uiplane ue;
    
    void Start()
    {
        
        PV.RPC("name_tag",RpcTarget.All);
        
        if(PV.IsMine)
        {
            Debug.Log("this is main");
            
            wi.enabled = false;
            gameObject.tag = "Player";
            Destroy(bc);
        }
        else
        {

            bc.enabled = true;
            gi.enabled = false;
            gb.enabled = false;
            pl.enabled = false;
            ac.enabled = false;
            aco.enabled = false;
            au.enabled = false;
            aa.enabled = false;
            // ue.enabled = true;
            
            Destroy(canvas);
            Destroy(cam);
            Destroy(rb);
            wi.enabled = true;

        }
        Debug.Log(PV.Owner.NickName);
        Debug.Log("he is in the team "+(PhotonNetwork.CurrentRoom.CustomProperties[PV.Owner.NickName]).ToString());
    }
    [PunRPC]
    void name_tag()
    {
        wi.textDescription = PV.Owner.NickName;
    }

   
}}
