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
        resourceTxt.text = $"��ȭ : { ResourceManager.instance.GetRsc()}";
        if (selectManager.selectedSO.level >= 5)
        {
            requireResourceTxt.text = "�ְ� ����!";
        }
        else
        {
            requireResourceTxt.text = $"�ʿ� ��ȭ : {selectManager.selectedPriceSO.TrainPrice[selectManager.selectedSO.level - 1]}";

        }
    }
}
