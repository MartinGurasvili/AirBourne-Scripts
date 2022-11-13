using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;


    public class uiplane : MonoBehaviour
    {
        public TMP_Text spd;
        public TMP_Text throttletxt;
        public Slider throttle;
        public float health = 100;
        public float oldhealth = 100;
        public TMP_Text healthtxt;
        public Slider healthbar;
        public AeroplaneController m_Aeroplane;
        public GameObject respawn;
        public AudioClip splash;
        private AudioSource ad;
        public GameObject camerae;
        public GameObject exp;
        public GameObject[] smoke;
        public GlitchEffect glitch;
        
        private PhotonView PV;
        public GameObject killog;
        public GameObject killobj;
        private bool alreadyExecuted = false;

        private bool aded = false;
    
        private string namee;


        void Start()
        {
            PV = GetComponent<PhotonView>();
            m_Aeroplane = GetComponent<AeroplaneController>();
            ad = GetComponent<AudioSource>();
            killog = GameObject.FindWithTag("kill");
            glitch.enabled = false;
            
        }

        void Update()
        {
            if(!PV.IsMine)
            {
                return;
            }
            spd.text = ((int)(gameObject.GetComponent<Rigidbody>().velocity.magnitude *2)).ToString() + " km/h";
            
            throttle.value = m_Aeroplane.Throttle;
            throttletxt.text = ((int)(m_Aeroplane.Throttle * 100)).ToString() + "%";
            healthtxt.text = health.ToString() + "%";
            healthbar.value = health;

            if(health == 100)
            {
                aded = false;
                alreadyExecuted = false;
                smoke[0].SetActive(false);
                smoke[1].SetActive(false);
                smoke[2].SetActive(false);
                smoke[3].SetActive(false);
            }
            if(health <= 50)
            {
                smoke[0].SetActive(true);
                smoke[1].SetActive(true);

            }
            if (health <= 25)
            {
                smoke[2].SetActive(true);
                smoke[3].SetActive(true);

            }
            if (health <= 0)
            {
                if(aded ==false)
                {
                    GameObject a = PhotonNetwork.Instantiate("exp", Vector3.zero,Quaternion.identity);
                    a.transform.position = gameObject.transform.position;
                    a.transform.parent = gameObject.transform ;
                    
                    aded =true;
                }
                
                health = 0;
                dead();
            }
            if(oldhealth !=health)
            {
                gothit();
                oldhealth=health;
            }
            

        }
        void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.tag == "else")
            {
                
                health = 0;
                if(!alreadyExecuted) {
                    killlog("Ground");
                    alreadyExecuted = true;
                }
            }
            if (col.gameObject.tag == "carry")
            {
                
                health = 0;
                if(!alreadyExecuted) {
                    killlog("Ship");
                    alreadyExecuted = true;
                }
            }
            if (col.gameObject.tag == "plane")
            {
                
                health = 0;
                if(!alreadyExecuted) {
                    killlog("Plane");
                    alreadyExecuted = true;
                }
            }
        }
        void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.tag == "water")
            {
                health = 0;
                ad.clip = splash;
                ad.volume = 0.4f;
                ad.priority = 0;
                ad.Play();
                if(!alreadyExecuted) {
                    killlog("Water");
                    alreadyExecuted = true;
                }
                
            }
        }
        public void killlog(string one)
        {
            PV.RPC("_killlog",RpcTarget.All,one);
        }
        [PunRPC]
        void _killlog(string one)
        {
            GameObject kill = Instantiate(killobj, killobj.transform.position, killobj.transform.rotation, killog.transform);
            kill.transform.SetParent(killog.transform);
            if(one!=null)
            {
                GameObject.FindWithTag("one").GetComponent<TMP_Text>().text = one;
            }
            else{
                GameObject.FindWithTag("one").GetComponent<TMP_Text>().text = "Plane";
            }
            GameObject.FindWithTag("one").GetComponent<TMP_Text>().text = one;
            GameObject.FindWithTag("two").GetComponent<TMP_Text>().text = PV.Owner.NickName;
            
            if(PhotonNetwork.CurrentRoom.CustomProperties[PV.Owner.NickName].ToString() == "0")
            {
                GameObject.FindWithTag("two").GetComponent<TMP_Text>().color = new Color(135, 0, 0, 110);

            }
            else{
                GameObject.FindWithTag("one").GetComponent<TMP_Text>().color = new Color(135, 0, 0, 110);
            }
    
        }
        public void dead()
        {
            if(namee!=null)
            {
                if(!alreadyExecuted){
                    killlog(namee);
                    alreadyExecuted = true;
                }
            }
            
    
            camerae.SetActive(false);
            glitch.enabled = true;
            respawn.SetActive(true);
            throttle.value = 0f;
            m_Aeroplane.Throttle = throttle.value;

        }
        
        public void takedam(int dam,string usern)
        {
            PV.RPC("ptakedam",RpcTarget.All,dam);
            
            health -= dam;
            PV.RPC("_namee",RpcTarget.All,usern);
        }
        [PunRPC]
        void ptakedam(int dam)
        {
            if(!PV.IsMine)
            {
                return;
            }
            health -= dam;
        }

        [PunRPC]
        void _namee(string usern)
        {
            namee = usern;
        }

        public void res()
        {
            PV.RPC("_res",RpcTarget.All);
            health = 100;
        }
        [PunRPC]
        void _res()
        {
            health = 100;
        }
        public void gothit()
        {
            GameObject can = GameObject.FindWithTag("hit");
            can.GetComponent<Animator>().Play("hit");
            can.GetComponent<Animator>().SetBool("done", true);
        }
    }

