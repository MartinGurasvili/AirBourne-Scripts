using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using Cinemachine;
using TMPro;
public class gunbangtut : MonoBehaviour
{
    public int bulletcount = 60;
    public int missilecount = 6;
    public TMP_Text bul;
    public TMP_Text mis;
    public GameObject barrel;
    public GameObject bullet;
    public GameObject flash;
    public GameObject hitmark;


    public float firerate = 15f;
    public float nextfire = 0f;
    private float misnextfire = 0f;

    private float timer = 5f;
    private int count = 0;

    public ParticleSystem flashp;
    public float hit = 0;

    public GameObject[] missiles;
    public int miscount = 0;
    public GameObject missile;

    public GameObject regcam;
    public GameObject zoomcam;

    public bool locking;
    public GameObject lockfab;

    public float locktimer;

    private getinfotut gi;
    private Transform taget;

    public TMP_Text locktxt;


    void Update()
    {

        gi = gameObject.GetComponent<getinfotut>();
        taget = gi.rayject;
        timer += Time.deltaTime;

        locktimer += Time.deltaTime;

        bul.text = bulletcount.ToString() + "/60";
        mis.text = missilecount.ToString() + "/6";

        GameObject pl = GameObject.FindWithTag("Player");
        uiplanetut ue = pl.GetComponent<uiplanetut>(); 
        
        
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
                if (Input.GetButton("Fire1") && Time.time >= nextfire)
                {
                    nextfire = Time.time + 1f / firerate;
                    Shoot();
                    
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
            if (missilecount > 0)
            {
                if (Input.GetKeyDown(KeyCode.F) && locking == true && Time.time >= misnextfire)
                {
                    misnextfire = Time.time + 1f /1;
                    homingfire();
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

        if (bulletcount <= 0  && count == 0)
        {
            bul.color = new Color32(255,0,0,120);
            timer = 0;
            count = 1;
        }
        if(timer > 4f && timer < 5f)
        {
            bulletcount = 60;
            count = 0;
            bul.color = new Color32(255,255,255,120);
        }
        if(missilecount == 0)
        {
            mis.color = new Color32(255,0,0,120);
        }
        
        
        

    }
    void Shoot()
    {
        
        GameObject a = Instantiate(bullet);
        a.transform.position = barrel.transform.position;
        a.transform.rotation = barrel.transform.rotation;

        
        AudioSource ad = flashp.GetComponent<AudioSource>();
        ad.Play();
        bulletcount -= 1;
    }
    public void hitmarkt()
    {
        hitmark.SetActive(true);
    }
    void homingfire()
    {
        GameObject b = Instantiate(missile);
        b.transform.position = missiles[miscount].transform.position;
        b.transform.rotation = barrel.transform.rotation;
        missiles[miscount].SetActive(false);
        miscount += 1;
        missilecount -= 1;
    }
}
