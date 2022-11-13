using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using Photon.Realtime ;

public class RoomListItem : MonoBehaviourPunCallbacks
{
    public RoomInfo info;
    public TMP_Text text;
    public void SetUp(RoomInfo _info)
    {
        info = _info;
        // text.text = _info.Name + " "+((PhotonNetwork.PlayerList).Length).ToString()+"/10";
        if(info.CustomProperties["Maps"] !=null){
            
            if((string)info.CustomProperties["Maps"] =="0")
            {
                text.text = _info.Name + "  "+"Evening  "+_info.PlayerCount.ToString()+"/10";
            }
            if((string)_info.CustomProperties["Maps"] =="1")
            {
                text.text = _info.Name + "  "+"Rain     "+_info.PlayerCount.ToString()+"/10";
            }
            if((string)info.CustomProperties["Maps"] =="2")
            {
                text.text = _info.Name + "  "+"Morning  "+_info.PlayerCount.ToString()+"/10";
            }
            Debug.Log("wwben");
        }
        
        
        
    }
    public void OnClick()
    {
        launcher.Instance.JoinRoom(info);
    }
}
