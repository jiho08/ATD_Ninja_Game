using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageViewManager : MonoBehaviour
{
    public GameObject Stage1;
    public GameObject Stage2;
    public GameObject Stage3;
    public GameObject Stage4;
    public GameObject Stage5;
    public GameObject Stage6;



    void Start()
    {
        Stage1.SetActive(false);
        Stage2.SetActive(false);
        Stage3.SetActive(false);
        Stage4.SetActive(false);
        Stage5.SetActive(false);
        Stage6.SetActive(false);
    }

  

    public void SetStageView6()
    {
        Stage1.SetActive(false);
        Stage2.SetActive(false);
        Stage3.SetActive(false);
        Stage4.SetActive(false);
        Stage5.SetActive(false);
        Stage6.SetActive(true);
    }
    public void SetStageView5()
    {
        Stage1.SetActive(false);
        Stage2.SetActive(false);
        Stage3.SetActive(false);
        Stage4.SetActive(false);
        Stage5.SetActive(true);
        Stage6.SetActive(false);
    }
    public void SetStageView4()
    {
        Stage1.SetActive(false);
        Stage2.SetActive(false);
        Stage3.SetActive(false);
        Stage4.SetActive(true);
        Stage5.SetActive(false);
        Stage6.SetActive(false);
    }
    public void SetStageView3()
    {
        Stage1.SetActive(false);
        Stage2.SetActive(false);
        Stage3.SetActive(true);
        Stage4.SetActive(false);
        Stage5.SetActive(false);
        Stage6.SetActive(false);
    }
    public void SetStageView2()
    {
        Stage1.SetActive(false);
        Stage2.SetActive(true);
        Stage3.SetActive(false);
        Stage4.SetActive(false);
        Stage5.SetActive(false);
        Stage6.SetActive(false);
    }
    public void SetStageView1()
    {
        Stage1.SetActive(true);
        Stage2.SetActive(false);
        Stage3.SetActive(false);
        Stage4.SetActive(false);
        Stage5.SetActive(false);
        Stage6.SetActive(false);
    }


}
