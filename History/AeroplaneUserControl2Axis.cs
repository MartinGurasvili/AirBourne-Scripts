using System;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using TMPro;
namespace UnityStandardAssets.Vehicles.Aeroplane
{
    public class AeroplaneUserControl2Axis : MonoBehaviour
    {
        // these max angles are only used on mobile, due to the way pitch and roll input are handled
        public float maxRollAngle = 80;
        public float maxPitchAngle = 80;

        public float sen1;
        public float sen2;
        // reference to the aeroplane that we're controlling
        private AeroplaneController m_Aeroplane;

        public TMP_Text health;
        private int up = 0;
        public GameObject option;
        public GameObject ocam;
        public GameObject cine;

        public GameObject crosshair;
        public int opt = 0;
        
        private bool lockedout = false;
        private bool c = false;
        public GameObject winscreen;
        private void Awake()
        {
            // Set up the reference to the aeroplane controller.
            m_Aeroplane = GetComponent<AeroplaneController>();
            
        }


        void FixedUpdate()
        {
            if(winscreen == null){
                winscreen = GameObject.FindGameObjectWithTag("win");
            }
            else{
                lockedout = true;
                Cursor.lockState = CursorLockMode.None;
            }
            m_Aeroplane = GetComponent<AeroplaneController>();
            
            // Read input for the pitch, yaw, roll and throttle of the aeroplane.
            float roll = CrossPlatformInputManager.GetAxis("Horizontal")  ;
            float pitch = CrossPlatformInputManager.GetAxis("Vertical");

            float mpitch = Input.GetAxis("vertical") * sen2;
            float mroll = Input.GetAxis("horizontal") * sen1;
            if(Input.GetAxis("horizontal") != 0)
            {
                
                roll = Input.GetAxis("horizontal") * sen1;
            }
            if(Input.GetAxis("Mouse X") != 0)
            {
                
                roll = Input.GetAxis("Mouse X") * sen1;
            }
            if(Input.GetAxis("vertical") != 0)
            {
                
                pitch = Input.GetAxis("vertical") * sen2;
            }
            if(Input.GetAxis("Mouse Y") != 0)
            {
                
                pitch = Input.GetAxis("Mouse Y") * sen2;
            }
            
            bool airBrakes = false;
            float throttle = 0;
            if(health.text == "0%")
            {
                lockedout = true;
            }

            if (((int)(gameObject.GetComponent<Rigidbody>().velocity.magnitude * 2)) > 40)
            {
                m_Aeroplane.m_AerodynamicEffect = 0.8f;
            }
            else
            {
                m_Aeroplane.m_AerodynamicEffect = 0;
            }

            if (up == 0)
            {
                if (Input.GetKeyDown(KeyCode.G))
                {
                    gameObject.GetComponent<Animator>().Play("gear up");
                    gameObject.GetComponent<Rigidbody>().mass = 2;
                    up = 1;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.G))
                {
                    gameObject.GetComponent<Animator>().Play("gear down");
                    gameObject.GetComponent<Rigidbody>().mass = 3;
                    up = 0;
                    
                }
            }
            
            if (Input.GetKey(KeyCode.LeftControl))
            {
                if(m_Aeroplane.Throttle > 0)
                {
                    throttle = m_Aeroplane.Throttle;
                    m_Aeroplane.Throttle = throttle - 0.01f;
    
                }
            }
            if (opt == 0)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    
                    option.SetActive(true);
                    lockedout = true;
                    opt = 1;

                }
            }
            else
            {
                lockedout = true;
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    lockedout = false;
                    option.SetActive(false);
                    opt = 0;
                }
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                lockedout = true;
                ocam.SetActive(true);
                cine.SetActive(false);
                
                c = true;
            }
            if (Input.GetKeyUp(KeyCode.C))
            {
                lockedout = false;
                ocam.SetActive(false);
                cine.SetActive(true);
                
                c = false;
                    
                
            }


            if (Input.GetKey(KeyCode.LeftShift))
            {

                if (m_Aeroplane.Throttle < 1)
                {
                    throttle = m_Aeroplane.Throttle;
                    m_Aeroplane.Throttle = throttle + 0.015f;
                }
            }
           
           if(lockedout == false)
           {
                m_Aeroplane.Move(roll, pitch, 0, throttle, airBrakes);
                Cursor.lockState = CursorLockMode.Locked;
                if(crosshair != null)
                {
                    crosshair.SetActive(true);
                }
                
           }
           else
           {
               m_Aeroplane.Move(mroll, mpitch, 0, throttle, airBrakes);
               if(crosshair != null)
                {
                    crosshair.SetActive(false);
                }
               
               if(c == false)
                {
                    Cursor.lockState = CursorLockMode.None;
                }
                else{
                    Cursor.lockState = CursorLockMode.Locked;
                }

           }

            
           
            

        }
        public void back()
        {
            lockedout = false;
        }
  

        // #if MOBILE_INPUT
        //             AdjustInputForMobileControls(ref roll, ref pitch, ref throttle);
        // #endif
                   
        //         }


        //         private void AdjustInputForMobileControls(ref float roll, ref float pitch, ref float throttle)
        //         {
        //             // because mobile tilt is used for roll and pitch, we help out by
        //             // assuming that a centered level device means the user
        //             // wants to fly straight and level!

        //             // this means on mobile, the input represents the *desired* roll angle of the aeroplane,
        //             // and the roll input is calculated to achieve that.
        //             // whereas on non-mobile, the input directly controls the roll of the aeroplane.

        //             float intendedRollAngle = roll*maxRollAngle*Mathf.Deg2Rad;
        //             float intendedPitchAngle = pitch*maxPitchAngle*Mathf.Deg2Rad;
        //             roll = Mathf.Clamp((intendedRollAngle - m_Aeroplane.RollAngle), -1, 1);
        //             pitch = Mathf.Clamp((intendedPitchAngle - m_Aeroplane.PitchAngle), -1, 1);

        //             // similarly, the throttle axis input is considered to be the desired absolute value, not a relative change to current throttle.
        //             float intendedThrottle = throttle*0.5f + 0.5f;
        //             throttle = Mathf.Clamp(intendedThrottle - m_Aeroplane.Throttle, -1, 1);
        //         }
        //     }
    }
}

