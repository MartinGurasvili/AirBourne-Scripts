using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class parse : MonoBehaviour
{
    public TMP_Text one;
    public TMP_Text two;
    void Update()
    {
        if(one.text == "test" ||two.text == "test")
        {
            Destroy(gameObject);
        }
    }
}
