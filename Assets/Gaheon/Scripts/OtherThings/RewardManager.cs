using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RewardManager : MonoBehaviour
{
    [SerializeField] Image stationImage;
    [SerializeField] TextMeshProUGUI clearText;
    [SerializeField] TextMeshProUGUI[] rewardTexts;
    [SerializeField] StationInfoSO stationInfo;
    [SerializeField] Image trainImageSprite;
    [SerializeField] GameObject trainImage;
    [SerializeField] GetStageNumberSo stageOpenSO;
    [SerializeField] GameObject rewardPanel;
    [SerializeField] OwningUnitSO owningUnit;
    [SerializeField] toMainMenuSO mainMenuSO;


  
    int clearStage;
    private void Update()
    {
        if (mainMenuSO.DidWinGame == true)
        {
            rewardPanel.SetActive(true);
            RewardChange();
        }
        else
        {
            rewardPanel.SetActive(false);
        }
    }
    void RewardChange()
    {
        clearStage = mainMenuSO.whichStageEnded; //완료된 스테이지 갖고 오는 거, 스테이지 열리는 거 설정은 각 스테이지의 GameManager가 mainMenuSO 만져주면서 바뀜

        stationImage.sprite = stationInfo.StationImages[clearStage];
        clearText.text = $"{stationInfo.stationNames[clearStage]}\n격파!";
        rewardTexts[0].text = $"획득 고철 : {stationInfo.rewardResources[clearStage]}";
        if (clearStage < 2)
        {
            rewardTexts[2].text = $"열린 스테이지 : {stationInfo.stationNames[clearStage + 1]}";

            rewardTexts[1].text = $"획득 유닛 : {stationInfo.unitSO[clearStage].TrainName}";
            trainImageSprite.sprite = stationInfo.unitSO[clearStage].TrainHead;
            if (stationInfo.unitSO[clearStage].TrainName == "KTX")
            {
                owningUnit.OwningKTX = true;
            }
            else if (stationInfo.unitSO[clearStage].TrainName == "1호선")
            {
                owningUnit.OwningLine1 = true;
            }
        }
        else
        {
            rewardTexts[1].text = "모든 기차 획득!";
            rewardTexts[1].alignment = TextAlignmentOptions.Midline;
            trainImage.SetActive(false);
            rewardTexts[2].text = "모든 맵 격파!";
        }
    }
    public void Confirm()
    {
        ResourceManager.instance.SetRsc(stationInfo.rewardResources[clearStage]);

        rewardPanel.SetActive(false);

        mainMenuSO.DidWinGame = false;
    }
}
