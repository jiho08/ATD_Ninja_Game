using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class StageViewManager : MonoBehaviour
{
    [Header("Stages")]
    public StageViewsData Mokpo;
    public StageViewsData Gwangju;
    public StageViewsData Busan;
    public StageViewsData Gyeongju;
    public StageViewsData Suwon;
    public StageViewsData Seoul;


    [SerializeField] public Image StageImage;
    [SerializeField] public TextMeshProUGUI StageName;

    public void SetStageview(int value)
    {
        switch (value)
        {
            case 0:
                StageImage.sprite = Mokpo.Stage;
                StageName.text = Mokpo.name;
                break;
            case 1:
                StageImage.sprite = Gwangju.Stage;
                StageName.text = Gwangju.name;
                break;
            case 2:
                StageImage.sprite = Busan.Stage;
                StageName.text = Busan.name;
                break;
            case 3:
                StageImage.sprite = Gyeongju.Stage;
                StageName.text = Gyeongju.name;
                break;
            case 4:
                StageImage.sprite = Suwon.Stage;
                StageName.text = Suwon.name;
                break;
            default:
                StageImage.sprite = Seoul.Stage;
                StageName.text = Seoul.name;
                break;
        }
    }
}
