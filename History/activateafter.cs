using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateafter : MonoBehaviour
{
    public GameObject activated;
    void Update()
    {
        if(GameObject.FindWithTag("MainCamera") !=null)
        {
            activated.SetActive(true);
            Destroy(this);
        }
    }
}
