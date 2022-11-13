using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class gameman : MonoBehaviour
{
   
    public Animator main;
    public Animator select;
    public GameObject [] playbuttons;
    public GameObject [] planemod;
    public TextMeshProUGUI planename;
    private string []names = {"TopGun","Maverick","Baracuda"} ;
    public int count = 0;
    private int prevcount ;

    public int botcount = 4;
    public TMP_Text bots;

    public int mapcount = 0;
    public TMP_Text maps;

    private int multi = 0;

    public GameObject cred;
    public GameObject serv;
    public GameObject login;
    public GameObject mainser;
    public GameObject roon;

    public GameObject join;

    void Start() {
        PlayerPrefs.SetInt("planeindex", 0);
        PlayerPrefs.SetInt("botcount", botcount);
        bots.text = botcount.ToString();
        maps.text = mapcount.ToString();
    }

    public void changestuff()
    {
        planemod[prevcount].SetActive(false);
        planemod[count].SetActive(true);
        planename.SetText(names[count]);

    }
    public void switch_select()
    {
        main.Play("Base Layer.SLIDE");
        select.gameObject.SetActive(true);
        select.Play("Base Layer.fade in");
        playbuttons[multi].SetActive(true);

    }
    public void switch_main()
    {
        select.Play("Base Layer.fade out");
        main.Play("Base Layer.slidein");
        playbuttons[multi].SetActive(false);
        multi = 0;
        

    }
    public void credits()
    {
        main.Play("Base Layer.SLIDE");
        cred.SetActive(true);
    }
    public void serverbrowser()
    {
        select.Play("Base Layer.fade out");
        playbuttons[multi].SetActive(false);
        serv.SetActive(true);
    }
    public void serverbrowserout()
    {
        select.Play("Base Layer.fade in");
        playbuttons[multi].SetActive(true);
        serv.SetActive(false);
    }
    public void Login()
    {
        login.SetActive(false);
        mainser.SetActive(true);
    }
    public void loginout()
    {
        mainser.SetActive(false);
        login.SetActive(true);
    }

    public void joinserv()
    {
        roon.SetActive(false);
        join.SetActive(true);
        mainser.SetActive(false);
    }
    public void joinservout()
    {
        join.SetActive(false);
        mainser.SetActive(true);
    }

    public void createroom()
    {
        roon.SetActive(true);
        mainser.SetActive(false);
    }
    public void createroomout()
    {
        mainser.SetActive(true);
        roon.SetActive(false);
    }
    public void creditsout()
    {
        main.Play("Base Layer.slidein");
        cred.SetActive(false);
    }

    public void multiplay()
    {
        multi = 1;
        switch_select();
    }
    public void backward()
    {
        if(count != 0)
        {

            prevcount = count;
            count -=1;
            PlayerPrefs.SetInt("planeindex", count);
            changestuff();

        }
        
    }
    public void forward()
    {
        if(count < 2)
        {
            prevcount = count;
            count +=1;
            PlayerPrefs.SetInt("planeindex", count);
            changestuff();
        }
    }
    public void exit()
    {
        Application.Quit();
    }

    public void botplus()
    {
       if(botcount <6)
        {
            botcount +=1;
            bots.text = botcount.ToString();
            PlayerPrefs.SetInt("botcount", botcount);
        }
        
    }
    public void botminus()
    {
        if(botcount != 0)
        {
            botcount -=1;
            bots.text = botcount.ToString();
            PlayerPrefs.SetInt("botcount", botcount);
            
        }
    }
    public void mapplus()
    {
       if(mapcount <2)
        {
            mapcount +=1;
            maps.text = mapcount.ToString();
            PlayerPrefs.SetInt("mapcount", mapcount);
        }
        
    }
    public void mapminus()
    {
        if(mapcount != 0)
        {
            mapcount -=1;
            maps.text = mapcount.ToString();
            PlayerPrefs.SetInt("mapcount", mapcount);
            
        }
    }
}
