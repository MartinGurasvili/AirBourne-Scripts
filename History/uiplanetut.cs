using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;


    public class uiplanetut : MonoBehaviour
    {
        public TMP_Text spd;
        public TMP_Text throttletxt;
        public Slider throttle;
        public float health = 100;
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
        



        void Start()
        {
            m_Aeroplane = GetComponent<AeroplaneController>();
            ad = GetComponent<AudioSource>();
            glitch.enabled = false;
        }

        void Update()
        {
            
            spd.text = ((int)(gameObject.GetComponent<Rigidbody>().velocity.magnitude *2)).ToString() + " km/h";
            
            throttle.value = m_Aeroplane.Throttle;
            throttletxt.text = ((int)(m_Aeroplane.Throttle * 100)).ToString() + "%";
            healthtxt.text = health.ToString() + "%";
            healthbar.value = health;


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
                exp.SetActive(true);
                health = 0;
                dead();
            }

        }
        void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.tag == "else")
            {
                health = 0;
            }
            if (col.gameObject.tag == "carry")
            {
                health = 0;
            }
        }
        void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.tag == "water")
            {
                health = 0;
                ad.clip = splash;
                ad.volume = 1;
                ad.priority = 0;
                ad.Play();
            }
        }
        public void dead()
        {
            
            camerae.SetActive(false);
            glitch.enabled = true;
            respawn.SetActive(true);
            throttle.value = 0f;
            m_Aeroplane.Throttle = throttle.value;

        }
    }

