using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{

    private string [] tutdio = {"Hey Trainee,I have heard great things about you back at the academy","Now that you have remote control, lets see if it was all talk",
    "Hold C Key to Free Look","Shift to increase throttle","Control to decrease","Great job your in the air","G Key to Raise Land Gear","Great job","F key to fire missle when locked on","Left mouse trigger to fire machine gun","Oh NO, we are detecting an enemy ship and plane nearby","Well Done, your training is complete","Feel Free to fly around if you want"} ;
    private string [] tuttask = {"-Take Off","-Raise Land Gear","-Test Weapons","-Eliminate Enemy Plane","-Destroy Enemy Ship"} ;

    private int taskindex;
    public TypeWriterEffect obj;
    public TypeWriterEffect talk;

    public bool takeoff = false;
    public bool shooty = false;

    public bool planey = true;

    public bool shipy = false;

    public enemytut planecs;
    public enemytut shipcs;

    // Start is called before the first frame update
    void Start()
    {
        taskindex=PlayerPrefs.GetInt("taskindex", 0);
        if(taskindex ==0)
        {
            StartCoroutine(starttut());
        }
        if(taskindex ==1)
        {
            StartCoroutine(plane());
        }
    }

    // Update is called once per frame
    void Update()
    {   
        if(taskindex != 1)
        {
            if(takeoff == true)
            {
                if (Input.GetKeyDown(KeyCode.G))
                {
                    shooty = true;
                    StartCoroutine(shoot());
                    takeoff = false;
                }
                
            }
            if(shooty == true)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    shooty = true;
                    PlayerPrefs.SetInt("taskindex", 1);
                    StartCoroutine(plane());
                    
                }
            }
        }
        else
        {
            if(planey == true)
            {
                if(planecs == null)
                {
                    StartCoroutine(ship());
                    planey = false;
                    shipy = true;
                }
            }
            if(shipy == true)
            {
                if( shipcs == null)
                {
                    StartCoroutine(end());
                    shipy = false;
                }
            }
            
        }
        
        //PlayerPrefs.SetInt("dioindex", dioindex);
        //
    }
    void OnTriggerEnter(Collider other) {
        if(taskindex != 1)
        {
            if (other.tag == "tut") {
                takeoff = true;
                StartCoroutine(gear());
            }
        }
    }
     
    //  void OnTriggerExit(Collider other) {
    //     if (other.tag == "tut") {
    //         takeoff = false;
    //     }
    //  }
    IEnumerator starttut()
    {
        talk.gameObject.GetComponent<TypeWriterEffect>().fullText = tutdio[0];
        talk.gameObject.GetComponent<TypeWriterEffect>().TypeText();

        yield return new WaitForSeconds(10);
        talk.gameObject.GetComponent<TypeWriterEffect>().currentText ="";
        talk.gameObject.GetComponent<TypeWriterEffect>().fullText = tutdio[1];
        talk.gameObject.GetComponent<TypeWriterEffect>().TypeText();

        yield return new WaitForSeconds(8);

        obj.gameObject.GetComponent<TypeWriterEffect>().fullText = tuttask [0];
        obj.gameObject.GetComponent<TypeWriterEffect>().TypeText();

        yield return new WaitForSeconds(2);
        talk.gameObject.GetComponent<TypeWriterEffect>().currentText ="";
        talk.gameObject.GetComponent<TypeWriterEffect>().fullText = tutdio[2];
        talk.gameObject.GetComponent<TypeWriterEffect>().TypeText();
        yield return new WaitForSeconds(8);
        talk.gameObject.GetComponent<TypeWriterEffect>().currentText ="";
        talk.gameObject.GetComponent<TypeWriterEffect>().fullText = tutdio[3];
        talk.gameObject.GetComponent<TypeWriterEffect>().TypeText();
        yield return new WaitForSeconds(6);
        talk.gameObject.GetComponent<TypeWriterEffect>().currentText ="";
        talk.gameObject.GetComponent<TypeWriterEffect>().fullText = tutdio[4];
        talk.gameObject.GetComponent<TypeWriterEffect>().TypeText();
        yield return new WaitForSeconds(4);
        talk.gameObject.GetComponent<TypeWriterEffect>().fullText ="";
        talk.gameObject.GetComponent<TypeWriterEffect>().TypeText();

       
    }
    IEnumerator gear()
    {
        obj.gameObject.GetComponent<TypeWriterEffect>().currentText ="";
        obj.gameObject.GetComponent<TypeWriterEffect>().fullText = tuttask [1];
        obj.gameObject.GetComponent<TypeWriterEffect>().TypeText();

        talk.gameObject.GetComponent<TypeWriterEffect>().currentText ="";
        talk.gameObject.GetComponent<TypeWriterEffect>().fullText = tutdio[5];
        talk.gameObject.GetComponent<TypeWriterEffect>().TypeText();

        yield return new WaitForSeconds(5);
        talk.gameObject.GetComponent<TypeWriterEffect>().currentText ="";
        talk.gameObject.GetComponent<TypeWriterEffect>().fullText = tutdio[6];
        talk.gameObject.GetComponent<TypeWriterEffect>().TypeText();
        yield return new WaitForSeconds(4);
        talk.gameObject.GetComponent<TypeWriterEffect>().fullText ="";
        talk.gameObject.GetComponent<TypeWriterEffect>().TypeText();


    }
    IEnumerator shoot()
    {
        obj.gameObject.GetComponent<TypeWriterEffect>().currentText ="";
        obj.gameObject.GetComponent<TypeWriterEffect>().fullText = tuttask [2];
        obj.gameObject.GetComponent<TypeWriterEffect>().TypeText();

        talk.gameObject.GetComponent<TypeWriterEffect>().currentText ="";
        talk.gameObject.GetComponent<TypeWriterEffect>().fullText = tutdio[7];
        talk.gameObject.GetComponent<TypeWriterEffect>().TypeText();

        yield return new WaitForSeconds(3);
        talk.gameObject.GetComponent<TypeWriterEffect>().currentText ="";
        talk.gameObject.GetComponent<TypeWriterEffect>().fullText = tutdio[8];
        talk.gameObject.GetComponent<TypeWriterEffect>().TypeText();
        yield return new WaitForSeconds(7);
        talk.gameObject.GetComponent<TypeWriterEffect>().currentText ="";
        talk.gameObject.GetComponent<TypeWriterEffect>().fullText = tutdio[9];
        talk.gameObject.GetComponent<TypeWriterEffect>().TypeText();
        yield return new WaitForSeconds(6);
        talk.gameObject.GetComponent<TypeWriterEffect>().fullText ="";
        talk.gameObject.GetComponent<TypeWriterEffect>().TypeText();


    }
    IEnumerator plane()
    {
        talk.gameObject.GetComponent<TypeWriterEffect>().fullText = tutdio[10];
        talk.gameObject.GetComponent<TypeWriterEffect>().TypeText();

        obj.gameObject.GetComponent<TypeWriterEffect>().fullText = tuttask [3];
        obj.gameObject.GetComponent<TypeWriterEffect>().TypeText();

        yield return new WaitForSeconds(10);
        talk.gameObject.GetComponent<TypeWriterEffect>().fullText ="";
        talk.gameObject.GetComponent<TypeWriterEffect>().TypeText();

       
    }
    IEnumerator ship()
    {
        obj.gameObject.GetComponent<TypeWriterEffect>().fullText = tuttask [4];
        obj.gameObject.GetComponent<TypeWriterEffect>().TypeText();
        yield return new WaitForSeconds(3);
    }
    IEnumerator end()
    {
        obj.gameObject.GetComponent<TypeWriterEffect>().fullText = "";
        obj.gameObject.GetComponent<TypeWriterEffect>().TypeText();
        talk.gameObject.GetComponent<TypeWriterEffect>().fullText = tutdio[11];
        talk.gameObject.GetComponent<TypeWriterEffect>().TypeText();
        yield return new WaitForSeconds(8);
        talk.gameObject.GetComponent<TypeWriterEffect>().fullText = tutdio[12];
        talk.gameObject.GetComponent<TypeWriterEffect>().TypeText();
        yield return new WaitForSeconds(8);
        talk.gameObject.GetComponent<TypeWriterEffect>().fullText ="";
        talk.gameObject.GetComponent<TypeWriterEffect>().TypeText();
        
    }
}
