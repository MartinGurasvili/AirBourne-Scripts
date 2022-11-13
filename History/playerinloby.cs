using Photon.Pun;
using Photon.Realtime ;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class playerinloby : MonoBehaviourPunCallbacks 
{
    
    public TMP_Text text;
    Player player;
    public void SetUp(Player _player)
    {
        player = _player;
        text.text = player.NickName;
        
    }

    public override void OnPlayerLeftRoom(Player otherplayer)
    {
        if(player == otherplayer)
        {
            Destroy(gameObject);
        }
    }
    public override void OnLeftRoom()
    {
        Destroy(gameObject);
        
    }
}
