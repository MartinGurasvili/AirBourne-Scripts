using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using System.IO;

public class roomman : MonoBehaviourPunCallbacks
{
    public static roomman Instance;

    void Awake() {
        if(Instance)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        //Instance = this;
    }
    public override void OnEnable() {
        base.OnEnable();
        SceneManager.sceneLoaded += OnSceneLoaded;

    }
    public override void OnDisable() {
        base.OnDisable();
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode lsm)
    {
        if(scene.buildIndex == 3 ||scene.buildIndex == 5||scene.buildIndex == 4)
        {
            PhotonNetwork.Instantiate(Path.Combine("Playerman","Player man"),Vector3.zero,Quaternion.identity);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
