using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullettut : MonoBehaviour
{
    public float speed;
    public Rigidbody rig;

    private gunbangtut gu;

    void Update()
    {
        GameObject pl = GameObject.FindWithTag("Player");
        gu = pl.GetComponent<gunbangtut>();

        rig.velocity = transform.forward * speed;
        
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "car")
        {
            Debug.Log("hit car");
            enemytut em = col.transform.GetComponent<enemytut>();
            em.health -= 5;
            gu.hitmarkt();
            Destroy(gameObject);

        }
        if (col.gameObject.tag == "carry")
        {
            enemytut em = col.transform.GetComponent<enemytut>();
            em.health -= 1;
            gu.hitmarkt();
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "plane")
        {
            enemytut em = col.transform.GetComponent<enemytut>();
            em.health -= 2;
            gu.hitmarkt();
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "turret")
        {
            enemytut em = col.transform.GetComponent<enemytut>();
            em.health -= 5;
            gu.hitmarkt();
            Destroy(gameObject);
        }

    }
    
}
