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
        resourceTxt.text = $"��ö : { ResourceManager.instance.GetRsc()}";
    }
    public void ChangeUpgradePrice()
    {
        if (selectManager.selectedSO.level >= 5)
        {
            upgradePriceTxt.text = "�ְ� ����!";
        }
        else
        {
            upgradePriceTxt.text = $"�ʿ� ��ö : {selectManager.selectedPriceSO.UpgradePrice[selectManager.selectedSO.level - 1]}";
        }
    }

    public void ChangeAddPrice()
    {
        if (selectManager.selectedSO.length >= 3)
        {
            addPriceTxt.text = "�ִ� ĭ��!";
        }
        else
        {
            addPriceTxt.text = $"�ʿ� ��ö : {selectManager.selectedPriceSO.AddPrice[selectManager.selectedSO.length - 1]}";

        }
    }
}
