using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using TMPro;

public class LengthManager : MonoBehaviour
{
    [SerializeField] SelectManager selectManager;
    [SerializeField] ResourceTxtManager resourceTxtManger;
    [SerializeField] TextMeshProUGUI lengthTxt;
    [SerializeField] GameObject[] trains;
    [SerializeField] Transform[] trainTransform;
    [SerializeField] BoxCollider2D[] trainCollider;
    [SerializeField] Animator[] trainAnimator;

    [SerializeField] float moveSpeed;

    
    Vector3[] trainPos = new Vector3[3];
    Vector3 startPos = new Vector3(-20, 0, 0);

    int trainLength;
    private void Start()
    {
        ResetTrainPos();

    }
    public void LengthChange()
    {
        if (selectManager.selectedSO.length < 2 && ResourceManager.instance.Resource >= selectManager.selectedPriceSO.AddPrice[selectManager.selectedSO.length])
        {
            selectManager.selectedSO.length++;
            OnLengthChange();
            resourceTxtManger.ChangeAddPrice();
            ResourceManager.instance.Resource = -selectManager.selectedPriceSO.AddPrice[selectManager.selectedSO.length - 1];
            resourceTxtManger.ChangeResource();
            AudioManager.Instance.PlaySfx(AudioManager.Sfx.Level);
        }
        else
        {
            AudioManager.Instance.PlaySfx(AudioManager.Sfx.Warning);
        }
    }

    public void ResetTrainPos()
    {
        foreach (Transform item in trainTransform)
        {
            item.localPosition = startPos;
            item.transform.DOKill();
        }
        OnLengthChange();
    }
    void OnLengthChange()
    {
        trainLength = selectManager.selectedSO.length + 1;
        lengthTxt.text = $"���� ĭ �� : {trainLength}/3";

        for (int i = 0; i < trainLength; i++)
        {
            trains[i].SetActive(true);
            if(i != 0)
            {
                trainAnimator[i].SetBool("IsBody", true);
            }
        }
        for (int i = 2; i > trainLength; i--)
        {
            trains[i].SetActive(false);
        }

        //�밡�� ^_^... 
        if (trainLength == 1)
        {
            trainPos[0] = new Vector3((trainCollider[0].size / 2 * 0).x, trainTransform[0].position.y, 0);
            trainTransform[0].DOMove(trainPos[0], moveSpeed);
        }
        else if (trainLength == 2)
        {
            trainPos[0] = new Vector3((trainCollider[0].size / 2 * 1).x, trainTransform[0].position.y, 0);
            trainPos[1] = new Vector3((trainCollider[1].size / 2 * -1).x, trainTransform[0].position.y, 0);
            trainTransform[0].DOMove(trainPos[0], moveSpeed);
            trainTransform[1].DOMove(trainPos[1], moveSpeed);
        }
        else if (trainLength == 3)
        {
            trainPos[0] = new Vector3(((trainCollider[0].size / 2 * 1).x + (trainCollider[1].size / 2 * 1).x), trainTransform[0].position.y, 0);
            trainPos[1] = new Vector3((trainCollider[1].size / 2 * 0).x, trainTransform[0].position.y, 0);
            trainPos[2] = new Vector3((trainCollider[1].size / 2 * -2).x, trainTransform[0].position.y, 0);
            trainTransform[0].DOMove(trainPos[0], moveSpeed);
            trainTransform[1].DOMove(trainPos[1], moveSpeed);
            trainTransform[2].DOMove(trainPos[2], moveSpeed);
        }

    }
}