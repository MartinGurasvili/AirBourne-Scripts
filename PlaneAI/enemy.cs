using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;
using Photon.Realtime ;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using System.IO;

public class enemy : MonoBehaviour
{
    public int health = 100;
    public GameObject exp;
    public Slider slide;
    public GameObject killog;
    public GameObject killobj;

    public Waypoint_Indicator wi;
    public PhotonView PV;

    private bool alreadyExecuted = false;

    private string namee;



    void Start()
    {
        if (transform.parent.tag == "shipr"){
            
            slide = GameObject.FindWithTag("slider").GetComponent<Slider>();
        }
        else
        {
            slide = GameObject.FindWithTag("slideb").GetComponent<Slider>();
        }
        killog = GameObject.FindWithTag("kill");

    }
    void Update()
    {
        if(health <= 0)
        {
            if(!alreadyExecuted)
            {
                if (transform.parent.tag == "shipr"){
                    
                    Hashtable Teams = new Hashtable();
                    Teams.Add("R33d", (float)PhotonNetwork.CurrentRoom.CustomProperties["R33d"] - 10);
                    PhotonNetwork.CurrentRoom.SetCustomProperties(Teams);
                    //PhotonNetwork.CurrentRoom.CustomProperties["R33d"] = (float)PhotonNetwork.CurrentRoom.CustomProperties["R33d"] - 10;
                }
                else
                {
                    Hashtable Teams = new Hashtable();
                    Teams.Add("B1u3", (float)PhotonNetwork.CurrentRoom.CustomProperties["B1u3"] - 10);
                    PhotonNetwork.CurrentRoom.SetCustomProperties(Teams);
                    //PhotonNetwork.CurrentRoom.CustomProperties["B1u3"] = (float)PhotonNetwork.CurrentRoom.CustomProperties["B1u3"] - 10;
                }
                
                PV.RPC("Dead",RpcTarget.All);
                alreadyExecuted = true;
            }
            
        }
    }
    [PunRPC]
    void Dead()
    {
        if(gameObject.GetComponent<multiai>() ==null)
        {
            GameObject a = PhotonNetwork.Instantiate("exp big", Vector3.zero,Quaternion.identity);
            a.transform.position = gameObject.transform.position;
        }
        else
        {
            GameObject a = PhotonNetwork.Instantiate("exp", Vector3.zero,Quaternion.identity);
            a.transform.position = gameObject.transform.position;
        }
       
        ////GameObject a = Instantiate(exp);
       
        wi.enabled = false;
        killog = GameObject.FindWithTag("kill");
        GameObject kill = Instantiate(killobj, killobj.transform.position, killobj.transform.rotation, killog.transform);
        kill.transform.SetParent(killog.transform);
        if(namee!=null)
        {
            GameObject.FindWithTag("one").GetComponent<TMP_Text>().text = namee;
        }
        else{
            GameObject.FindWithTag("one").GetComponent<TMP_Text>().text = "World";
        }
        if(gameObject.GetComponent<multiai>() ==null)
        {
            GameObject.FindWithTag("two").GetComponent<TMP_Text>().text = "Ship";
        }
        else
        {
            GameObject.FindWithTag("two").GetComponent<TMP_Text>().text = "Bot";
        }
        
        
        if (transform.parent.tag == "shipr"){
            
            GameObject.FindWithTag("two").GetComponent<TMP_Text>().color = new Color(135, 0, 0, 110);
        }
        else
        {
            GameObject.FindWithTag("one").GetComponent<TMP_Text>().color = new Color(135, 0, 0, 110);
        }
        Destroy(this);
    }

    public void Takedam(int dam,string usern)
    {
        PV.RPC("_Takedam",RpcTarget.All,dam);
        PV.RPC("_namee",RpcTarget.All,usern);
        
    }
    [PunRPC]
    void _Takedam(int dam)
    {
        if(gameObject.GetComponent<multiai>() ==null)
        {
            health = health - dam;
        }
        else{
            health = health - dam*3;
        }
            
    }
    [PunRPC]
    void _namee(string usern)
    {
        namee = usern;
    }
    
}
