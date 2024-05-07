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

    private void Start()
    {
        RewardChange();
    }
    void RewardChange()
    {

    }
}
