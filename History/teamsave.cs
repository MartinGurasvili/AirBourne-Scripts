using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class teamsave : MonoBehaviour
{
    public Transform red;
    public Transform blue;

    
    void Update()
    {
        
        foreach(Transform trans in red)
        {
            if(trans.GetComponent<TMP_Text>().text == PhotonNetwork.NickName)
            {
                PlayerPrefs.SetInt("Team", 0);
                //Debug.Log("your in red team");
            }
        }
        foreach(Transform transs in blue)
        {
            if(transs.GetComponent<TMP_Text>().text == PhotonNetwork.NickName)
            {
                PlayerPrefs.SetInt("Team", 1);
                //Debug.Log("your in blue team");
            }
        }
    }
}

