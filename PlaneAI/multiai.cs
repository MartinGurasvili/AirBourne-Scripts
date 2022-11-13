using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Photon.Realtime ;
using Photon.Pun;


public class multiai : MonoBehaviour
    {
        public Transform taget;
        public Transform me;
        public Rigidbody rig;

        public float turn = 700;
        public float spd = 500;

    
        public GameObject [] Wappoints;
    

        public GameObject bullet;
        public GameObject barrel;

        private Quaternion targetrot;


        public float range = 1500;

        public float nextfire = 0f;


        public float bullet_count = 30;

        public ParticleSystem flashp; 

        public enemy em;

        public GameObject [] fireef;

        public GameObject missile;

        public AudioSource ad;
        private bool lok = false;

        private bool got_point = false;
        public Transform waytaget;
        public delete del;

        private int team;
        void Start()
        {
            Wappoints = GameObject.FindGameObjectsWithTag("waypoint");
            if(gameObject.transform.parent.tag == "shipr")
            {
                team = 0;
            }
            else if(gameObject.transform.parent.tag == "shipb")
            {
                team = 1;
            }
            else{
                Debug.Log("ur wrong");
            }
        }

        void FixedUpdate()
        {
            GameObject pl = GameObject.FindWithTag("Player");
        
            if(em.health > 0)
            {
                if(taget == null)
                {
                    patrol();
                    find_player();
                        
                }
                else
                {
                    if(Vector3.Distance(taget.transform.position, transform.position) > 1000)
                    {
                        taget = null;
                
                    }
                    chase();
                }
                if(em.health < 51){
                    fireef[0].SetActive(true);
                }
                if(em.health < 26){
                    fireef[1].SetActive(true);
                }
            }
            else
            {
                del.enabled = true;
            }
            

        }
        public void find_player()
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("plane");
            //players.Add(GameObject.FindWithTag("Player"));
            foreach(GameObject g in players)
            {
                if(team ==0)
                {
                    if(PhotonNetwork.CurrentRoom.CustomProperties[g.GetComponent<PhotonView>().Owner.NickName].ToString() == "1"){
                        if(Vector3.Distance(g.transform.position, transform.position) < 1000)
                        {
                            taget = g.transform;
                    
                        }
                    }
                    if(GameObject.FindWithTag("Player")!=null)
                    {
                    if(PhotonNetwork.CurrentRoom.CustomProperties[GameObject.FindWithTag("Player").GetComponent<PhotonView>().Owner.NickName].ToString() == "1"){
                        if(Vector3.Distance(GameObject.FindWithTag("Player").transform.position, transform.position) < 1000)
                        {
                            taget = GameObject.FindWithTag("Player").transform;
                    
                        }
                    }
                    }
                    
                }
                else{
                    if(PhotonNetwork.CurrentRoom.CustomProperties[g.GetComponent<PhotonView>().Owner.NickName].ToString() == "0"){
                        if(Vector3.Distance(g.transform.position, transform.position) < 1000)
                        {
                            taget = g.transform;
                    
                        }
                    }
                    if(GameObject.FindWithTag("Player")!=null)
                    {
                    if(PhotonNetwork.CurrentRoom.CustomProperties[GameObject.FindWithTag("Player").GetComponent<PhotonView>().Owner.NickName].ToString() == "0"){
                        if(Vector3.Distance(GameObject.FindWithTag("Player").transform.position, transform.position) < 1000)
                        {
                            taget = GameObject.FindWithTag("Player").transform;
                    
                        }
                    }
                    }
                    
                }
            }
        }

        void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.tag == "else")
            {
                
                em.health = 0;
                
            }
            if (col.gameObject.tag == "carry")
            {
                
                em.health = 0;
                
            }
            
        }
        void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.tag == "water")
            {
                em.health = 0;
                
                
            }
        }

        public void patrol()
        {
            rig.velocity = transform.forward * spd;
            if(got_point == false){
                waytaget = Wappoints[Random.Range(0, Wappoints.Length)].transform;
                got_point = true;
            }
            if(Vector3.Distance (me.transform.position, waytaget.position) < 100)
            {
                got_point = false;
            }
            
            targetrot = Quaternion.LookRotation(waytaget.position - transform.position);
            rig.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetrot, turn));

        }

        public void chase()
        {
            
            rig.velocity = transform.forward * spd;
            targetrot = Quaternion.LookRotation(taget.position - transform.position);
            rig.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetrot, turn));
            
            if(bullet_count <= 0){
                StartCoroutine(reload());

            }
            else
            {
                
                spd = 110;
                RaycastHit hit;
                
                if (Physics.Raycast(barrel.transform.position, barrel.transform.forward, out hit))
                {
                    if (hit.transform.tag == "Player" && Time.time >= nextfire)
                    {
                        nextfire = Time.time + 1f / 20;
                        Shoot();
                        spd = 120;
                        
                    }

                    if (hit.transform.tag == "Player")
                    {
                        if (!lok)
                        {
                            lok = true;
                            StartCoroutine(homing());
                        }   
                    }
                
                    if (hit.transform.tag == "water" )
                    {
                        spd = spd/2;
                        rig.AddForce(transform.up * spd*10);  
                    }
                    
                }
            }
        }

        void Shoot()
        {
            
            GameObject a = Instantiate(bullet);
            a.transform.position = barrel.transform.position;
            a.transform.rotation = barrel.transform.rotation;

            
            AudioSource ad = flashp.GetComponent<AudioSource>();
            ad.Play();
            bullet_count -= 1;
        }

        void homingfire()
        {
            GameObject b = Instantiate(missile);
            b.transform.position = barrel.transform.position;
            b.transform.rotation = barrel.transform.rotation; 
        }

        IEnumerator homing()
        {
            ad.Play();
            yield return new WaitForSeconds(3);
            homingfire();
            yield return new WaitForSeconds(3);
            ad.Stop();
            yield return new WaitForSeconds(3);
            lok = false;
        }
        IEnumerator reload()
        {
            yield return new WaitForSeconds(3);
            bullet_count = 30;
        }
    }
