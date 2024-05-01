using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourceTxtManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI resourceTxt;
    [SerializeField] TextMeshProUGUI requireResourceTxt;
    [SerializeField] SelectManager selectManager;

    private void Start()
    {
        ResourceManager.instance.SetRsc(0 - ResourceManager.instance.GetRsc());
        ChangeResourceTxt();
    }

    public void ChangeResourceTxt()
    {
        resourceTxt.text = $"재화 : { ResourceManager.instance.GetRsc()}";
        if (selectManager.selectedSO.level >= 5)
        {
            requireResourceTxt.text = "최고 레벨!";
        }
        else
        {
            requireResourceTxt.text = $"필요 재화 : {selectManager.selectedPriceSO.TrainPrice[selectManager.selectedSO.level - 1]}";

        }
    }
}
