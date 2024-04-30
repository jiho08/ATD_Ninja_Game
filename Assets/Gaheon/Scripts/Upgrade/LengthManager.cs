using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using TMPro;

public class LengthManager : MonoBehaviour
{
    [SerializeField] SelectManager selectManager;
    [SerializeField] TextMeshProUGUI lengthTxt;
    [SerializeField] GameObject[] Trains;
    [SerializeField] Transform[] trainTransform;

    [SerializeField] float moveSpeed;

    Vector3[] trainPos = new Vector3[3];
    private void Start()
    {
        WhenLengthChange();
    }
    public void LengthChange()
    {
        if (selectManager.selectedSO.length < 3)
        {
            selectManager.selectedSO.length++;
            WhenLengthChange();
        }
    }
    public void WhenLengthChange()
    {
        lengthTxt.text = $"±âÂ÷ Ä­ ¼ö : {selectManager.selectedSO.length}/3";

        for (int i = 0; i < selectManager.selectedSO.length; i++)
        {
            Trains[i].SetActive(true);
        }
        for (int i = 2; i > selectManager.selectedSO.length - 1; i--)
        {
            Trains[i].SetActive(false);
        }

        //trainPos[0] = new Vector3((selectManager.trainCollider[0].size / 2 * (selectManager.selectedSO.length - 1)).x, trainTransform[0].position.y, 0);
        if (selectManager.selectedSO.length >= 2)
        
        trainTransform[0].DOMove(trainPos[0], moveSpeed);
        trainTransform[1].DOMove(trainPos[1], moveSpeed);
        trainTransform[2].DOMove(trainPos[2], moveSpeed);

        for (int i = 0; i < selectManager.selectedSO.length - 1; i++)
        {
        }
    }
}
