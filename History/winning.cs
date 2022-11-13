using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Realtime ;
using Photon.Pun;

public class winning : MonoBehaviour
{
    public Slider red;
    public Slider blue;
    public TMP_Text title;
    public GameObject Won;
    public GameObject cam;
    public GameObject wintext;

    public GameObject redd;
    public GameObject bluee;

    private bool alreadyExecuted = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(red.value <= 0)
        {
            
            Won.SetActive(true);
            title.text = "Dark-Water Won";
            title.color = new Color(0, 0, 1, 1);
            if(!alreadyExecuted) {
                winn();
                alreadyExecuted = true;
            }
        }
        if(blue.value <= 0)
        {
            Won.SetActive(true);
            title.text = "Fire-Bird Won" ;
            title.color = new Color(1, 0, 0, 1);
            if(!alreadyExecuted) {
                winn();
                alreadyExecuted = true;
            }
            
            
        }
        
    }
    public void winn()
    {
        Cursor.lockState = CursorLockMode.None;
        Instantiate(cam);
        Player [] players = PhotonNetwork.PlayerList;
        GameObject [] cams = GameObject.FindGameObjectsWithTag("cams");
        
        foreach(GameObject b in cams)
        {
            Destroy(b);
        }
        for (int i = 0; i < players.Length; i++)
        {
            
            if(PhotonNetwork.CurrentRoom.CustomProperties[players[i].NickName].ToString() == "0"){
                GameObject b = Instantiate(wintext, wintext.transform.position, wintext.transform.rotation, wintext.transform);
                b.GetComponent<TMP_Text>().text = players[i].NickName;
                b.transform.SetParent(redd.transform);
                
                
            }
            else{
                GameObject b = Instantiate(wintext, wintext.transform.position, wintext.transform.rotation, wintext.transform);
                b.GetComponent<TMP_Text>().text = players[i].NickName;
                b.transform.SetParent(bluee.transform);
                
            }
            
        }
        Cursor.lockState = CursorLockMode.None;
    }
}
