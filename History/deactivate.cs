using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deactivate : MonoBehaviour
{
    private float timer = 0;
    public float todelete;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > todelete)
        {
            gameObject.SetActive(false);
            timer = 0;
        }
    }
}
