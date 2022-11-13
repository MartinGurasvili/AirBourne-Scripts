using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PICKPLANE : MonoBehaviour
{
    public GameObject[] planes;
    // Start is called before the first frame update
    void Start()
    {
        int ie = Random.Range(0,planes.Length);
        planes[ie].SetActive(true);
    }


}
