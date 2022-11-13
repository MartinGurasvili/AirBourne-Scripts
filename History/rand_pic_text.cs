using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class rand_pic_text : MonoBehaviour
{
    public Texture [] imgs;
    public RawImage img;
    private string []hints = {"“Once you have tasted flight, you will forever walk the earth with your eyes turned skyward, for there you have been, and there you will always long to return.” - Leonardo Da Vinci","“Sometimes you have to go up really high to understand how small you are.” — Felix Baumgartner","“Flying may not be all plain sailing, but the fun of it is worth the price.” - Amelia Earhart.","“Great pilots are made not born.” - Johnnie Johnson","“My soul is in the sky.” - William Shakespeare"};
    public TextMeshProUGUI hint;
    void Start()
    {
        
        int num =  Random.Range(0,imgs.Length);
        img.texture = imgs[num];
        int num2 =  Random.Range(0,hints.Length);
        hint.SetText(hints[num2]);

    }


}
