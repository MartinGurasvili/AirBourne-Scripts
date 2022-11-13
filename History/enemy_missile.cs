using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class enemy_missile : MonoBehaviour
{
    public Transform taget;
    public Rigidbody rig;

    public float turn = 400;
    public float spd = 200;


    public GameObject exp;

    private Quaternion targetrot;


    void FixedUpdate()
    {
        GameObject pl = GameObject.FindWithTag("Player");

        rig.velocity = transform.forward * spd;
        if(taget != null)
        {
            if (!(Vector3.Distance (gameObject.transform.position, taget.position) < 5))
            {
                targetrot = Quaternion.LookRotation(taget.position - transform.position);
                rig.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetrot, turn));
            }
            
        }
        else
        {
            taget = GameObject.FindWithTag("Playercol").transform;
        }
        

        

    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Playercol")
        {
            Debug.Log("hit");
            GameObject a = Instantiate(exp);
            a.transform.position = gameObject.transform.position;
            GameObject pl = GameObject.FindWithTag("Player");
            uiplane ue = pl.GetComponent<uiplane>(); 
            ue.health -= 25;
            GameObject can = GameObject.FindWithTag("hit");
            can.GetComponent<Animator>().Play("hit");
            can.GetComponent<Animator>().SetBool("done", true);
            
            Destroy(gameObject);
        }

    }
}
