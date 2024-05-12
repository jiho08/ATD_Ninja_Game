using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] SelectManager selectManager;
    [SerializeField] BarManager barManager;
    [SerializeField] ResourceTxtManager resourceTxtManager;

    [SerializeField] TextMeshProUGUI ktxLevelText;
    [SerializeField] TextMeshProUGUI mghLevelText;
    [SerializeField] TextMeshProUGUI line1LevelText;

    float currentMoney;

    private void Start()
    {
        ChangeLevelText();
    }

    public void Upgrade()
    {
        currentMoney = ResourceManager.instance.Resource;
        if (selectManager.selectedSO.level < 5 && ResourceManager.instance.Resource >= selectManager.selectedPriceSO.UpgradePrice[selectManager.selectedSO.level - 1])
        {
            selectManager.selectedSO.level++;
            barManager.ChangeBar();
            ChangeLevelText();
            ResourceManager.instance.Resource = -selectManager.selectedPriceSO.UpgradePrice[selectManager.selectedSO.level - 1];
            resourceTxtManager.ChangeResource();
            resourceTxtManager.ChangeUpgradePrice();
            AudioManager.Instance.PlaySfx(AudioManager.Sfx.Level);
        }
        else
        {
            AudioManager.Instance.PlaySfx(AudioManager.Sfx.Warning);
        }
    }

    void ChangeLevelText()
    {
        ktxLevelText.text = $"{selectManager.ktxSO.level}/5";
        mghLevelText.text = $"{selectManager.mghSO.level}/5";
        line1LevelText.text = $"{selectManager.line1SO.level}/5";
    }
}
