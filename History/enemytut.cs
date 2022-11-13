using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemytut : MonoBehaviour
{
    public int health = 100;
    public GameObject exp;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            GameObject a = Instantiate(exp);
            a.transform.position = gameObject.transform.position;
            Destroy(gameObject);



        }
    }

    public void Takedam(int dam)
    {
        health = health - dam;
    }
}
