using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    private void Start()
    {
        if (mainMenuSO.DidWinGame == true)
        {
            if (stageOpenSO.isOpenStage[1] == true)
            {
                RewardChange();
            }
            else
            {
                rewardPanel.SetActive(false);
            }
        }
        else
        {
            rewardPanel.SetActive(false);
        }
    }
    void RewardChange()
    {
        for (int i = 0; i < 4; i++)
        {
            if (stageOpenSO.isOpenStage[i] == false)
            {
                clearStage = i - 2;
                break;
            }
        }

        stationImage.sprite = stationInfo.StationImages[clearStage];
        clearText.text = $"{stationInfo.stationNames[clearStage]}\n°ÝÆÄ!";
        rewardTexts[0].text = $"È¹µæ °íÃ¶ : {stationInfo.rewardResources[clearStage]}";
        if (clearStage < 2)
        {
            rewardTexts[2].text = $"¿­¸° ½ºÅ×ÀÌÁö : {stationInfo.stationNames[clearStage + 1]}";

            if (clearStage > 0)
            {
                rewardTexts[1].text = $"È¹µæ À¯´Ö : {stationInfo.unitSO[clearStage].TrainName}";
                trainImageSprite.sprite = stationInfo.unitSO[clearStage].TrainHead;
                if (stationInfo.unitSO[clearStage].TrainName == "KTX")
                {
                    owningUnit.OwningKTX = true;
                }
                else if (stationInfo.unitSO[clearStage].TrainName == "1È£¼±")
                {
                    owningUnit.OwningLine1 = true;
                }
            }
            else
            {
                rewardTexts[1].text = "È¹µæ À¯´Ö ¾øÀ½";
                rewardTexts[1].alignment = TextAlignmentOptions.Midline;
                trainImage.SetActive(false);
            }
        }
        else
        {
            rewardTexts[1].text = "¸ðµç ±âÂ÷ È¹µæ!";
            rewardTexts[1].alignment = TextAlignmentOptions.Midline;
            trainImage.SetActive(false);
            rewardTexts[2].text = "¸ðµç ¸Ê °ÝÆÄ!";
        }
    }
    public void Confirm()
    {
        ResourceManager.instance.SetRsc(stationInfo.rewardResources[clearStage]);
        rewardPanel.SetActive(false);
        Debug.Log(ResourceManager.instance.GetRsc());

        mainMenuSO.DidWinGame = false;
    }
}
