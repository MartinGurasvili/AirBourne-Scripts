using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rot : MonoBehaviour
{
    public GameObject obj;
    void Update()
    {
        gameObject.transform.rotation = obj.transform.rotation;
    }
}
