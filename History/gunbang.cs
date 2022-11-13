using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using Cinemachine;
using Photon.Pun;
using TMPro;

namespace UnityStandardAssets.Vehicles.Aeroplane{
public class gunbang : MonoBehaviour
{
    public int bulletcount = 60;
    public int missilecount = 6;
    public TMP_Text bul;
    public TMP_Text mis;
    public GameObject barrel;
    public GameObject bullet;
    public GameObject flash;
    public GameObject hitmark;
    
    private AeroplaneUserControl2Axis axiscon;

    public float firerate = 15f;
    public float nextfire = 0f;
    private float misnextfire = 0f;

    private float timer = 5f;
    private int count = 0;

    public ParticleSystem flashp;
    public float hit = 0;

    // public GameObject[] missiles;
    // public int miscount = 0;
    public GameObject missile;

    public GameObject regcam;
    public GameObject zoomcam;

    public bool locking;
    public GameObject lockfab;

    public float locktimer;

    private getinfo gi;
    private Transform taget;

    public TMP_Text locktxt;

    public AudioSource ad;

    public multiplay_respawn mr;
    PhotonView PV;
    void Start() {
        PV = gameObject.GetComponent<PhotonView>();
    }


    void Update()
    {
        if(!PV.IsMine)
        {
            return;
        }

        if(mr.running==true)
        {
            bulletcount = 60;
            missilecount = 6;
            mr.running = false;
            misnextfire = 0;
        }
        axiscon = gameObject.GetComponent<AeroplaneUserControl2Axis>();
        gi = gameObject.GetComponent<getinfo>();
        taget = gi.rayject;
        timer += Time.deltaTime;

        locktimer += Time.deltaTime;

        bul.text = bulletcount.ToString() + "/60";
        mis.text = missilecount.ToString() + "/6";

        GameObject pl = GameObject.FindWithTag("Player");
        uiplane ue = pl.GetComponent<uiplane>(); 
        
        
        if (Input.GetButtonDown("Fire2"))
        {
            //cine.m_Lens.FieldOfView = 20f;
            regcam.SetActive(false);
            zoomcam.SetActive(true);
            //cine.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenY = 0.98f;
        }
        if (Input.GetButtonUp("Fire2"))
        {

            regcam.SetActive(true);
            zoomcam.SetActive(false);
            //cine.m_Lens.FieldOfView = 50f;
            //cine.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenY = 0.8f;
        }
        
        if (ue.health !=0)
        {
            if (bulletcount >0)
            {
                if(axiscon.opt == 0)
                {
                    if (Input.GetButton("Fire1") && Time.time >= nextfire)
                    {
                        nextfire = Time.time + 1f / firerate;
                        Shoot();
                        // PV.RPC("Shoot",RpcTarget.All);
                        
                        
                    }
                    if (Input.GetButtonDown("Fire1"))
                    {
                        flashp.Play();
                    }
                    if (Input.GetButtonUp("Fire1"))
                    {
                        flashp.Stop();
                        
                    }
                }
                
            }
            if (missilecount > 0)
            {
                if (Input.GetKeyDown(KeyCode.F) && locking == true && Time.time >= misnextfire)
                {
                    misnextfire = Time.time + 1f /1;
                    homingfire();
                    // PV.RPC("homingfire",RpcTarget.All);
                    
                }
            }
        }
        if(taget != null)
        {
            Vector3 screenPoint = Camera.main.WorldToViewportPoint(taget.position);
            bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1 && Vector3.Distance(taget.position, transform.position) < 1000;
            if (onScreen)
            {
                locktxt.gameObject.SetActive(true);

                if (locktimer > 3)
                {
                    locking = true;
                    locktxt.text = "Locked";
                    
                }

            }
            else
            {
                locktxt.text = "Locking Onto Target";
                locktxt.gameObject.SetActive(false);
                locking = false;
                locktimer = 0;
            }
        }
        else{
            locktxt.gameObject.SetActive(false);
        }
        if(taget != null)
        {
            if (locking == true)
            {
                lockfab.gameObject.SetActive(true);
                lockfab.transform.position = Camera.main.WorldToScreenPoint(taget.transform.position);
            }
            if (locking == false)
            {
                lockfab.gameObject.SetActive(false);
            }
        }
        else
        {
            lockfab.gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            bul.color = new Color32(255,0,0,120);
            timer = 0;
            count = 1;
        }
        if (bulletcount <= 0  && count == 0)
        {
            bul.color = new Color32(255,0,0,120);
            timer = 0;
            count = 1;

        }
        if(timer > 4f && timer < 4.1f)
        {
            bulletcount = 60;
            count = 0;
            bul.color = new Color32(255,255,255,120);
            ad.Play();
        }
        if(missilecount == 0)
        {
            mis.color = new Color32(255,0,0,120);
        }
        if(missilecount == 6)
        {
            mis.color = new Color32(255,255,255,120);
        }
        
    }
    // [PunRPC]
    void Shoot()
    {
        GameObject Bullet_ = PhotonNetwork.Instantiate("bullet", barrel.transform.position, barrel.transform.rotation, 0);
        Bullet_.transform.parent = gameObject.transform;
        PV.RPC("bulletsound",RpcTarget.All);
        bulletcount -= 1;
    }
    public void hitmarkt()
    {
        hitmark.SetActive(true);
    }
    // [PunRPC]
    void homingfire()
    {
        GameObject missile_ = PhotonNetwork.Instantiate("missile", barrel.transform.position, barrel.transform.rotation, 0);
        missile_.transform.parent = gameObject.transform;
        // b.transform.position = barrel.transform.position;
        // b.transform.rotation = barrel.transform.rotation;
        // missiles[miscount].SetActive(false);
        // miscount += 1;
        missilecount -= 1;
    }
    [PunRPC]
    void bulletsound()
    {
        AudioSource ad = flashp.GetComponent<AudioSource>();
        ad.Play();
    }
}}
