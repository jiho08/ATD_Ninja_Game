using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MapButtonClick : MonoBehaviour
{
    public Camera mainCam;
    public GameObject MapPos;
    bool mapButtonClicked;
    [SerializeField] TextMeshProUGUI WorldMapButton;
    [SerializeField] GameObject Stages;
    [SerializeField] GameObject StageViews;
    [SerializeField] GameObject RedDot;


    private void Update()
    {
        if (mapButtonClicked)
        {
            mainCam.transform.position = Vector3.Slerp(mainCam.transform.position, MapPos.transform.position, 0.01f);
            WorldMapButton.text = "�κ�";
        }
        else if (!mapButtonClicked)
        {
            mainCam.transform.position = Vector3.Slerp(mainCam.transform.position, new Vector3(0,0,-10), 0.01f);
            WorldMapButton.text = "����";
        }


    }
    public void click(){
        if (mapButtonClicked)
        {
            mapButtonClicked = false;
        }
        else
        {
            mapButtonClicked = true;
        }
    }

}
