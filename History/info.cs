using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class info : MonoBehaviour
{
    //public Text shipTxt;
    //public Transform shipPos;

    //public Text planeTxt;
    //public Transform planePos;

    public RectTransform prefab;
    private RectTransform waypoint;

    void Start()
    {
        var canvas = GameObject.Find("Way").transform;
        waypoint = Instantiate(prefab, canvas);

        //shipTxt.gameObject.SetActive(true);
        //planeTxt.gameObject.SetActive(true);
        //shipTxt.transform.position = Camera.main.WorldToScreenPoint(shipPos.position);

    }

    void Update()
    {
        var screenPos = Camera.main.WorldToScreenPoint(transform.position);
        waypoint.position = screenPos;
        //shipTxt.transform.position = Camera.main.WorldToScreenPoint(shipPos.position);
        //planeTxt.transform.position = Camera.main.WorldToScreenPoint(planePos.position);
    }
}
