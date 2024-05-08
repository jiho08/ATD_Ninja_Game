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
            WorldMapButton.text = "로비";
        }
        else if (!mapButtonClicked)
        {
            mainCam.transform.position = Vector3.Slerp(mainCam.transform.position, new Vector3(0,0,-10), 0.01f);
            WorldMapButton.text = "지도";
        }


    }
    public void click(){
        if (mapButtonClicked)
        {
            mapButtonClicked = false;
            SetStageFalse();
        }
        else
        {
            mapButtonClicked = true;
            Invoke("SetStageTrue", 1);
        }
    }

    private void SetStageTrue()
    {
        Stages.SetActive(true);
        StageViews.SetActive(true);
        RedDot.SetActive(true);
    } 
    private void SetStageFalse()
    {
        Stages.SetActive(false);
        StageViews.SetActive(false);
        RedDot.SetActive(false);
    }
}
