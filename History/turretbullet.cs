using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretbullet : MonoBehaviour
{
    public float speed;
    public Rigidbody rig;
    public GameObject impactefx;

    void Update()
    {
        rig.velocity = transform.forward * speed;

    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Playercol")
        {
            GameObject spark = Instantiate(impactefx, col.transform);
            spark.transform.parent = col.gameObject.transform;
            // Debug.Log("hit plane");
            GameObject pl = GameObject.FindWithTag("Player");
            uiplane ue = pl.GetComponent<uiplane>(); 
            ue.health -= 2;
            GameObject can = GameObject.FindWithTag("hit");
            can.GetComponent<Animator>().Play("hit");
            can.GetComponent<Animator>().SetBool("done", true);
            Destroy(gameObject);
        }

    }
}
