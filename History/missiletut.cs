using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missiletut : MonoBehaviour
{
    public Transform taget;
    public Rigidbody rig;

    public float turn = 700;
    public float spd = 500;

    private getinfotut gi;
    private gunbangtut gu;

    public GameObject exp;

    private Quaternion targetrot;

    void FixedUpdate()
    {
        GameObject pl = GameObject.FindWithTag("Player");
        gu = pl.GetComponent<gunbangtut>();
        gi = pl.GetComponent<getinfotut>();
        taget = gi.rayject;
        rig.velocity = transform.forward * spd;
        if(taget != null)
        {
            targetrot = Quaternion.LookRotation(taget.position - transform.position);
            rig.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetrot, turn));
        }
        

        

    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "car")
        {
            GameObject a = Instantiate(exp);
            a.transform.position = gameObject.transform.position;
            Debug.Log("hit car");
            enemytut em = col.transform.GetComponent<enemytut>();
            em.health -= 100;
            gu.hitmarkt();
            Destroy(gameObject);

        }
        if (col.gameObject.tag == "carry")
        {
            GameObject a = Instantiate(exp);
            a.transform.position = gameObject.transform.position;
            enemytut em = col.transform.GetComponent<enemytut>();
            em.health -= 20;
            gu.hitmarkt();
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "plane")
        {
            GameObject a = Instantiate(exp);
            a.transform.position = gameObject.transform.position;
            enemytut em = col.transform.GetComponent<enemytut>();
            em.health -= 50;
            gu.hitmarkt();
            Destroy(gameObject);
        }

    }
}
