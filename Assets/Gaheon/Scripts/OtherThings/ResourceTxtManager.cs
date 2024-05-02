using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourceTxtManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI resourceTxt;
    [SerializeField] TextMeshProUGUI upgradePriceTxt;
    [SerializeField] TextMeshProUGUI addPriceTxt;
    [SerializeField] SelectManager selectManager;

    private void Start()
    {
        ResourceManager.instance.SetRsc(0 - ResourceManager.instance.GetRsc());
        ChangeResource();
        ChangeUpgradePrice();
        ChangeAddPrice();
    }

    public void ChangeResource()
    {
        resourceTxt.text = $"재화 : { ResourceManager.instance.GetRsc()}";
    }
    public void ChangeUpgradePrice()
    {
        if (selectManager.selectedSO.level >= 5)
        {
            upgradePriceTxt.text = "최고 레벨!";
        }
        else
        {
            upgradePriceTxt.text = $"필요 재화 : {selectManager.selectedPriceSO.UpgradePrice[selectManager.selectedSO.level - 1]}";
        }
    }

    public void ChangeAddPrice()
    {
        if (selectManager.selectedSO.length >= 3)
        {
            addPriceTxt.text = "최대 칸수!";
        }
        else
        {
            addPriceTxt.text = $"필요 재화 : {selectManager.selectedPriceSO.AddPrice[selectManager.selectedSO.length - 1]}";

        }
    }
}
