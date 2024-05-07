using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MapButtonClick : MonoBehaviour
{
    public Camera mainCam;
    public GameObject MapPos;
    bool mapButtonClicked;
    [SerializeField] GameObject Stages;
    [SerializeField] GameObject StageViews;
    [SerializeField] GameObject RedDot;


    private void Update()
    {
        if (mapButtonClicked)
        {
            mainCam.transform.position = Vector3.Slerp(mainCam.transform.position, MapPos.transform.position, 0.02f);
        }
        else if (!mapButtonClicked)
        {
            mainCam.transform.position = Vector3.Slerp(mainCam.transform.position, new Vector3(0,0,-10), 0.02f);
        }


    }
    public void clickWorldMap()
    {
            mapButtonClicked = true;
    }
    public void clickRobby()
    {
            mapButtonClicked = false;
    }

}
