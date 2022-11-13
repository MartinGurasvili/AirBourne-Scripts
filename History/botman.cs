using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.IO;

public class botman : MonoBehaviour
{
    public int botcount = 4;
    public GameObject planepre;
    public List<GameObject> allplanes = new List<GameObject>();
    public GameObject [] spawnred;
    public GameObject [] spawnblue;
    public GameObject red;
    public GameObject blue;
    public int team =1;

    public int rcount = 0;
    public int bcount = 0;
    PhotonView PV;
    private int continuee = 0;
    //private int temp;
    // Start is called before the first frame update
    void Start()
    {
       
        botcount = int.Parse(PhotonNetwork.CurrentRoom.CustomProperties["B0T5"].ToString());
    
        
        
        for(int i=0;i<botcount;i++)
        {
            instantspawn();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(red.transform.childCount != rcount)
        {
            int ie = Random.Range(0,5);
            while(continuee ==0)
            {
                ie = Random.Range(0,5);
                GameObject[] player = GameObject.FindGameObjectsWithTag("carry");
                GameObject[] players = GameObject.FindGameObjectsWithTag("else");
                foreach(GameObject g in player)
                {
                    if(Vector3.Distance(g.transform.position, transform.position) > 100)
                    {
                        continuee = 1;
                        break;
                    }
                }
                foreach(GameObject g in players)
                {
                    if(Vector3.Distance(g.transform.position, transform.position) > 100)
                    {
                        continuee = 1;
                        break;
                    }
                }
            }
            GameObject b = PhotonNetwork.Instantiate(Path.Combine("AI","AI"),Vector3.zero,Quaternion.identity);
            b.transform.position = spawnred[ie].transform.position;
            b.transform.rotation = Quaternion.Euler(spawnred[ie].transform.rotation.eulerAngles.x, spawnred[ie].transform.rotation.eulerAngles.y, spawnred[ie].transform.rotation.eulerAngles.z);
            //GameObject b = Instantiate(planepre, spawnred[ie].transform.position, spawnred[ie].transform.rotation);
            b.SetActive(true);
            b.transform.parent = red.transform ;
            allplanes.Add(b);
            continuee =0;
        }
        if(blue.transform.childCount != bcount)
        {
            int ie = Random.Range(0,5);
            while(continuee ==0)
            {
                ie = Random.Range(0,5);
                GameObject[] player = GameObject.FindGameObjectsWithTag("carry");
                GameObject[] players = GameObject.FindGameObjectsWithTag("else");
                foreach(GameObject g in player)
                {
                    if(Vector3.Distance(g.transform.position, transform.position) > 100)
                    {
                        continuee = 1;
                        break;
                    }
                }
                foreach(GameObject g in players)
                {
                    if(Vector3.Distance(g.transform.position, transform.position) > 100)
                    {
                        continuee = 1;
                        break;
                    }
                }
            }
            GameObject b = PhotonNetwork.Instantiate(Path.Combine("AI","AI"),Vector3.zero,Quaternion.identity);
            b.transform.position = spawnblue[ie].transform.position;
            b.transform.rotation = Quaternion.Euler(spawnblue[ie].transform.rotation.eulerAngles.x, spawnblue[ie].transform.rotation.eulerAngles.y, spawnblue[ie].transform.rotation.eulerAngles.z);
            //GameObject b = Instantiate(planepre, spawnblue[ie].transform.position, spawnblue[ie].transform.rotation);
            b.SetActive(true);
            b.transform.parent = blue.transform ;
            allplanes.Add(b);
            continuee =0;
        }
    }
    public void instantspawn()
    {
        
        if(team ==0)
        {
            int ie = Random.Range(0,5);
            GameObject b = PhotonNetwork.Instantiate(Path.Combine("AI","AI"),Vector3.zero,Quaternion.identity);
            b.transform.position = spawnred[ie].transform.position;
            b.transform.rotation = Quaternion.Euler(spawnred[ie].transform.rotation.eulerAngles.x, spawnred[ie].transform.rotation.eulerAngles.y, spawnred[ie].transform.rotation.eulerAngles.z);
            //GameObject b = Instantiate(planepre, spawnred[ie].transform.position, spawnred[ie].transform.rotation);
            
            b.SetActive(true);
            b.transform.parent = red.transform ;
            allplanes.Add(b);
            rcount +=1;
        
            team = 1;
            
            
            
        }
        else
        {
            int ie = Random.Range(0,5);
            GameObject b = PhotonNetwork.Instantiate(Path.Combine("AI","AI"),Vector3.zero,Quaternion.identity);
            b.transform.position = spawnblue[ie].transform.position;
            b.transform.rotation = Quaternion.Euler(spawnblue[ie].transform.rotation.eulerAngles.x, spawnblue[ie].transform.rotation.eulerAngles.y, spawnblue[ie].transform.rotation.eulerAngles.z);
            //GameObject b = Instantiate(planepre, spawnblue[ie].transform.position, spawnblue[ie].transform.rotation);
            
            b.SetActive(true);
            b.transform.parent = blue.transform ;
            allplanes.Add(b);
            bcount +=1;
        
            team = 0;
            
        }
    }
}
