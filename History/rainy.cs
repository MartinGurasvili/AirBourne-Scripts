using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rainy : MonoBehaviour
{
    public GameObject [] activateing;
    //public GameObject [] activatee;
    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 4)
        {
            foreach(GameObject thing in activateing)
            {
                thing.SetActive(true);
            }

            Destroy(this);
        }
        // else if(SceneManager.GetActiveScene().buildIndex == 4)
        // {
        //     foreach(GameObject thing in activatee)
        //     {
        //         thing.SetActive(true);
        //     }

        //     Destroy(this);
        //}
        else{
            Destroy(this);
        }
    }


}
