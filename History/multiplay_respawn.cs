using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class multiplay_respawn : MonoBehaviour
{
    public GameObject cam;
    public GameObject respawnmen;
    public GlitchEffect glitch;
    public uiplane ui;
    public AeroplaneController control;
    public plane_inst ie;
    public Animator fade;

    public bool running = false;

    public Quaternion pos; 

    private Rigidbody rig;

    public int team;
    
    void Start() {
        pos = gameObject.transform.rotation;
        rig = GetComponent<Rigidbody>();
    }
    public void respawn()
    {
        team = PlayerPrefs.GetInt("Team",0);
        rig.freezeRotation = true;
        running=true;
        fade.gameObject.SetActive(true);
        respawnmen.SetActive(false);
        
        cam.SetActive(true);
        control.Throttle = 1;
        ui.res();
        glitch.enabled = false;
        ie.instantspawn();
        ie.rest();
        Cursor.lockState = CursorLockMode.Locked;
        
        fade.gameObject.SetActive(true);
        fade.GetComponent<Animator>().Play("fade in black");
        rig.freezeRotation = false;
    }

}
