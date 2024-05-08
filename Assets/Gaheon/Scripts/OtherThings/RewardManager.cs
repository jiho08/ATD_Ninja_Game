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

    int clearStage;
    private void Start()
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
    void RewardChange()
    {
        for (int i = 0; i < 6; i++)
        {
            if (stageOpenSO.isOpenStage[i] == false)
            {
                clearStage = i - 2;
                break;
            }
        }

        stationImage.sprite = stationInfo.StationImages[clearStage];
        clearText.text = $"{stationInfo.stationNames[clearStage]}\n����!";
        rewardTexts[0].text = $"ȹ�� ��ǰ : {stationInfo.rewardResources[clearStage]}";
        if (clearStage < 3)
        {
            rewardTexts[2].text = $"���� �������� : {stationInfo.stationNames[clearStage + 1]}";

            if (clearStage > 0)
            {
                rewardTexts[1].text = $"ȹ�� ���� : {stationInfo.unitSO[clearStage].TrainName}";
                trainImageSprite.sprite = stationInfo.unitSO[clearStage].TrainHead;
            }
            else
            {
                rewardTexts[1].text = "ȹ�� ���� ����";
                rewardTexts[1].alignment = TextAlignmentOptions.Midline;
                trainImage.SetActive(false);
            }
        }
        else
        {
            rewardTexts[1].text = "��� ���� ȹ��!";
            rewardTexts[1].alignment = TextAlignmentOptions.Midline;
            trainImage.SetActive(false);
            rewardTexts[2].text = "��� �� ����!";
        }
    }
    public void Confirm()
    {
        rewardPanel.SetActive(false);
    }
}
