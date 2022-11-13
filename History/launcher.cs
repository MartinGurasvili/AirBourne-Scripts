using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime ;
using UnityEngine.UI;
using ExitGames.Client.Photon;
using System.Reflection;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using SupportClassPun = ExitGames.Client.Photon.SupportClass;
using UnityEngine.SceneManagement;




public class launcher : MonoBehaviourPunCallbacks  
{
    public GameObject before_page;
    public GameObject lobby_page;

    public static launcher Instance;
    public TMP_InputField namee;

    public TMP_InputField username;

    public TMP_Text lobbyname;
    
    public Transform rm; 
    public GameObject rmpree;

    public Transform blue; 
    public Transform red; 
    public GameObject plit;

    public GameObject hoststart;


    public GameObject canvas;


    public Slider fill;

    public int count = 0;

    public int joined = 0;

    public TMP_Text botstext;
    public TMP_Text maptext;


    // public Slider fill;
    void Awake() {
        Instance = this; 
    }
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    void Update()
    {
        if(joined == 1)
        {
            if(PhotonNetwork.CurrentRoom.IsOpen == false)
            {
                canvas.SetActive(true);
                StartCoroutine(progbar());
            }
        }
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("joined master");
        PhotonNetwork.JoinLobby();
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    public override void OnJoinedLobby()
    {
        Debug.Log("joined lobby");
        
    }

    public override void OnJoinedRoom()
    {
        
        int playerindex = PlayerPrefs.GetInt("planeindex",0);
        //int KillScore = (int)PhotonNetwork.player.customProperties["Plane"];
        //killScore++;
        Hashtable hash = new Hashtable();
        hash.Add("Plane", playerindex);
       
        


        Debug.Log("joined room");
        Hashtable Teams = new Hashtable();
        Teams.Add("R33d", 100f);
        Teams.Add("B1u3", 100f);
        Teams.Add("5t@rt", false);
        
        if(PhotonNetwork.IsMasterClient)
        {
            Teams.Add("B0T5", botstext.text.ToString());
            Teams.Add("M@P5", maptext.text.ToString());
        }
            
        Player [] players = PhotonNetwork.PlayerList;
        foreach(Transform trans in red)
        {
            Destroy(trans.gameObject);
        }
        foreach(Transform trans in blue)
        {
            Destroy(trans.gameObject);
        }
        for (int i = 0; i < players.Length; i++)
        {
            if(players[i].NickName == PhotonNetwork.NickName){
                players[i].SetCustomProperties(hash);
            }
            if(count == 0){
                Instantiate(plit,red).GetComponent<playerinloby>().SetUp(players[i]);
                Teams.Add(players[i].NickName.ToString(),0);
                Debug.Log(players[i].NickName);
                count = 1;
                
            }
            else{
                Instantiate(plit,blue).GetComponent<playerinloby>().SetUp(players[i]);
                Teams.Add(players[i].NickName.ToString(),1);
                Debug.Log(players[i].NickName);
                count = 0;
            }
            
        }
        RoomOptions ro=
        new RoomOptions()
        {
            IsVisible = true,
            IsOpen = true,
    
        };
        //ro.CustomRoomProperties = Teams;
        //string room = lobbyname.text;
        
        PhotonNetwork.CurrentRoom.SetCustomProperties(Teams);
        hoststart.SetActive(PhotonNetwork.IsMasterClient);
        joined = 1;
    }
    public override void OnMasterClientSwitched(Player newmaster)
    {
        hoststart.SetActive(PhotonNetwork.IsMasterClient);
    }
    public void CreateRoom()
    {
        RoomOptions roomOpts = new RoomOptions();
        roomOpts.CustomRoomProperties = new ExitGames.Client.Photon.Hashtable();
        roomOpts.CustomRoomProperties.Add("Maps",maptext.text.ToString() );
        roomOpts.CustomRoomPropertiesForLobby = new string[1] { "Maps"};
        if(namee.text != "")
        {
            PhotonNetwork.CreateRoom(namee.text, roomOpts, null);
        }
        else
        {
            namee.text = "Room "+ Random.Range(0,50).ToString();
            PhotonNetwork.CreateRoom(namee.text, roomOpts, null);
        }
        Debug.Log("joined room "+namee.text+ " "+PhotonNetwork.NickName);
        lobbyname.text = namee.text;
        
        
    } 
    public void JoinRoom(RoomInfo info)
    {
       
        PhotonNetwork.JoinRoom(info.Name);
        Debug.Log("joined room "+info.Name);
        lobbyname.text=info.Name;
        lobby_page.SetActive(true);
        before_page.SetActive(false);
    } 
    
    public void LeaveRoom()
    {
        count = 0;
        joined = 0;
        PhotonNetwork.LeaveRoom();
        Debug.Log("left room ");
    }
    public void namemaker()
    {
        if(username.text != "")
        {
            PhotonNetwork.NickName = username.text;
        }
        else
        {
            PhotonNetwork.NickName = "User "+ Random.Range(0,50).ToString();
        }
        
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomlist)
    {
        foreach(Transform trans in rm)
        {
            Destroy(trans.gameObject);
        }
        for (int i = 0; i<roomlist.Count;i++)
        {
            if (roomlist[i].RemovedFromList)
            {
                continue;
            }
            Instantiate(rmpree,rm).GetComponent<RoomListItem>().SetUp(roomlist[i]);
        }
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if(count == 0){
                Instantiate(plit,red).GetComponent<playerinloby>().SetUp(newPlayer);
                count = 1;
            }
            if(count == 1){
                Instantiate(plit,blue).GetComponent<playerinloby>().SetUp(newPlayer);
                count = 0;
            }
        
    }
    public void StartGame()
    {
        

        PhotonNetwork.CurrentRoom.IsOpen = false;
        PhotonNetwork.CurrentRoom.IsVisible = false;
        PhotonNetwork.CurrentRoom.CustomProperties["5t@rt"] = true;
        PhotonNetwork.LoadLevel(int.Parse(PhotonNetwork.CurrentRoom.CustomProperties["M@P5"].ToString())+3);

        base.photonView.RPC("canvasac",RpcTarget.All);
        StartCoroutine(progbar());
        Debug.Log("starting game ");
        
    }
    
    [PunRPC]
    void canvasac()
    {
        canvas.SetActive(true);
    }
    IEnumerator progbar()
    {
        yield return new WaitForSeconds(1);
        fill.value = 0.4f;
        yield return new WaitForSeconds(1);
        fill.value = 0.7f;
        yield return new WaitForSeconds(1);
        fill.value = 0.9f;
    }



}
