using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime ;

public class respawn : MonoBehaviour
{
    
    public void res()
    {
        SceneManager.LoadScene(2);
    }
    public void quit() {
        PhotonNetwork.LeaveRoom();
        Application.Quit();
    }
    public void main()
    {
        SceneManager.LoadScene(1);
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        Debug.Log("left room ");
        SceneManager.LoadScene(1);
    }
}
