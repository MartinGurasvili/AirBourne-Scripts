using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activeonstart : MonoBehaviour
{
    public GameObject g;
    void Start()
    {
        g.SetActive(true);
    }

}
