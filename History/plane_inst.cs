using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;

    public class plane_inst : MonoBehaviour
    {
        public GameObject [] planes;
        public GameObject [] spawnred;
        public GameObject [] spawnblue;
        private int index;
        private int ie;
        public int team = 0; //  0=red  1=blue

        private Transform red;
        private Transform blue;

        private GameObject [] redship;
        private GameObject [] blueship;
        PhotonView PV;
        private Slider rs;
        private Slider bs;

        private int continuee = 0;

        void Start() 
        {
            foreach(GameObject g in planes)
            {
                g.SetActive(false);
            }
            PV = gameObject.GetComponent<PhotonView>();
        
            team = PlayerPrefs.GetInt("Team",0);
            
            red = GameObject.FindGameObjectWithTag("red").transform;
            blue = GameObject.FindGameObjectWithTag("blue").transform;
            redship = GameObject.FindGameObjectsWithTag("shipr");
            blueship = GameObject.FindGameObjectsWithTag("shipb");
            if(team ==0)
            {
                int count = 0;
                foreach(Transform trans in red)
                {
                    spawnred[count] = (trans.gameObject);
                    count+=1;
                    
                }
                foreach(GameObject trans in redship)
                {
                    foreach(Transform transs in trans.transform)
                    {
                        transs.gameObject.tag = "else";
                        transs.GetComponent<Waypoint_Indicator>().enabled = false;
                    }
                }
            }
            else{
                int count = 0;
                foreach(Transform trans in blue)
                {
                    spawnblue[count] = (trans.gameObject);
                    count+=1;
                }
                foreach(GameObject trans in blueship)
                {
                    foreach(Transform transs in trans.transform)
                    {
                        transs.gameObject.tag = "else";
                        transs.GetComponent<Waypoint_Indicator>().enabled = false;
                    }
                }
            }
            StartCoroutine(ExampleCoroutine());
            

        }
   

        IEnumerator ExampleCoroutine()
        {
        
            yield return new WaitForSeconds(0.2f);
            PV.RPC("instantspawn",RpcTarget.All);
            otherp();
        }
        void Update()
        {
            redship = GameObject.FindGameObjectsWithTag("shipr");
            blueship = GameObject.FindGameObjectsWithTag("shipb");
            if(team ==0)
            {
                int count = 0;
                foreach(Transform trans in red)
                {
                    spawnred[count] = (trans.gameObject);
                    count+=1;
                    
                }
                foreach(GameObject trans in redship)
                {
                    foreach(Transform transs in trans.transform)
                    {
                        transs.gameObject.tag = "else";
                        transs.GetComponent<Waypoint_Indicator>().enabled = false;
                    }
                }
            }
            else{
                int count = 0;
                foreach(Transform trans in blue)
                {
                    spawnblue[count] = (trans.gameObject);
                    count+=1;
                }
                foreach(GameObject trans in blueship)
                {
                    foreach(Transform transs in trans.transform)
                    {
                        transs.gameObject.tag = "else";
                        transs.GetComponent<Waypoint_Indicator>().enabled = false;
                    }
                }
            }
        }
        
        public void rest()
        {
            if(team ==0)
            {
                rs = GameObject.FindWithTag("slider").GetComponent<Slider>();
                Hashtable Teams = new Hashtable();
                Teams.Add("R33d", (float)PhotonNetwork.CurrentRoom.CustomProperties["R33d"] - 5);
                PhotonNetwork.CurrentRoom.SetCustomProperties(Teams);
                //PhotonNetwork.CurrentRoom.CustomProperties["R33d"] = (float)PhotonNetwork.CurrentRoom.CustomProperties["R33d"] - 5;
            }
            else
            {
                Hashtable Teams = new Hashtable();
                Teams.Add("B1u3", (float)PhotonNetwork.CurrentRoom.CustomProperties["B1u3"] - 5);
                PhotonNetwork.CurrentRoom.SetCustomProperties(Teams);
                bs = GameObject.FindWithTag("slideb").GetComponent<Slider>();
                //PhotonNetwork.CurrentRoom.CustomProperties["B1u3"] = (float)PhotonNetwork.CurrentRoom.CustomProperties["B1u3"] - 5;
            }
            //PV.RPC("ress",RpcTarget.All);
        }
        public void otherp()
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("plane");
            foreach(GameObject g in players)
            {
                int num = (int)g.GetComponent<PhotonView>().Owner.CustomProperties["Plane"];
                if(num == 0)
                {
                    g.transform.GetChild(16).gameObject.SetActive(false);
                    g.transform.GetChild(17).gameObject.SetActive(false);
                }
                else if (num == 1)
                {
                    g.transform.GetChild(15).gameObject.SetActive(false);
                    g.transform.GetChild(17).gameObject.SetActive(false);
                }
                else
                {
                    g.transform.GetChild(15).gameObject.SetActive(false);
                    g.transform.GetChild(16).gameObject.SetActive(false);
                }
            }
        }

        [PunRPC]
        void ress()
        {
            if(team ==0)
            {
                rs = GameObject.FindWithTag("slider").GetComponent<Slider>();
                PhotonNetwork.CurrentRoom.CustomProperties["R33d"] = (float)PhotonNetwork.CurrentRoom.CustomProperties["R33d"] - 5;
            }
            else
            {
                bs = GameObject.FindWithTag("slideb").GetComponent<Slider>();
                PhotonNetwork.CurrentRoom.CustomProperties["B1u3"] = (float)PhotonNetwork.CurrentRoom.CustomProperties["B1u3"] - 5;
            }
        }
        [PunRPC]
        public void instantspawn()
        {
            
            if(team ==0)
            {
                int ie = Random.Range(0,5);
                // while(continuee ==0)
                // {
                //     int ie = Random.Range(0,5);
                //     GameObject[] players = GameObject.FindGameObjectsWithTag("else");
                //     continuee = 1;
                //     foreach(GameObject g in players)
                //     {
                //         if(Vector3.Distance(g.transform.position, spawnred[ie].transform.position) < 50)
                //         {
                //             continuee = 0;
                            
                //         }
                //     }
                // }
                
                gameObject.transform.position = spawnred[ie].transform.position;
                gameObject.transform.rotation = spawnred[ie].transform.rotation;
                gameObject.transform.rotation = spawnred[ie].transform.rotation;
                gameObject.transform.rotation = spawnred[ie].transform.rotation;
                gameObject.transform.rotation = spawnred[ie].transform.rotation;
                index=(int)PV.Owner.CustomProperties["Plane"];
                planes[index].SetActive(true);
                //continuee =0;
            }
            else
            {
                index=(int)PV.Owner.CustomProperties["Plane"];
                int ie = Random.Range(0,5);
                planes[index].SetActive(true);
                // while(continuee ==0)
                // {
                //     int ie = Random.Range(0,5);
                //     GameObject[] players = GameObject.FindGameObjectsWithTag("else");
                //     continuee = 1;
                //     foreach(GameObject g in players)
                //     {
                //         if(Vector3.Distance(g.transform.position, spawnblue[ie].transform.position) > 50)
                //         {
                //             continuee = 0;
                            
                //         }
                //     }
                // }
                gameObject.transform.position = spawnblue[ie].transform.position;
                gameObject.transform.rotation = spawnblue[ie].transform.rotation;
                gameObject.transform.rotation = spawnred[ie].transform.rotation;
                gameObject.transform.rotation = spawnred[ie].transform.rotation;
                gameObject.transform.rotation = spawnred[ie].transform.rotation;
                //continuee =0;
            }
        }
   }

