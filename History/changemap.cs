using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class changemap : MonoBehaviour
{
    public Texture [] img;
    public TMP_Text txt;
    private RawImage me;
    // Start is called before the first frame update
    void Start()
    {
        me = gameObject.GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        me.texture = img[int.Parse(txt.text)];
    }
}
