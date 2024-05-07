using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class BarManager : MonoBehaviour
{
    [SerializeField] SelectManager selectManager;

    [SerializeField] Image currentHpBar;
    [SerializeField] Image previewHpBar;
    [SerializeField] Image currentAtkBar;
    [SerializeField] Image previewAtkBar;
    [SerializeField] Image currentSpeedBar;
    [SerializeField] Image previewSpeedBar;

    float currentHp;
    float currentAtk;
    float currentSpeed;

    int currentLv;

    float previewHp;
    float previewAtk;
    float previewSpeed;


    void Start()
    {
    }


    public void ChangeBar()
    {
        selectManager.ChangeValue();

        currentHp = selectManager.selectedSO.Hp;
        currentAtk = selectManager.selectedSO.Atk;
        currentSpeed = selectManager.selectedSO.Speed;
        currentLv = selectManager.selectedSO.level;

        currentHpBar.transform.DOScale(new Vector3(currentHp, 1, 0), 1f);
        currentAtkBar.transform.DOScale(new Vector3(currentAtk, 1, 0), 1f);
        currentSpeedBar.transform.DOScale(new Vector3(currentSpeed, 1, 0), 1f);

        if (currentLv < 5)
        {

            previewHp = selectManager.selectedUnitLevel.Hp[currentLv];
            previewAtk = selectManager.selectedUnitLevel.Atk[currentLv];
            previewSpeed = selectManager.selectedUnitLevel.Speed[currentLv];

            previewHpBar.transform.DOScale(new Vector3(previewHp, 1, 0), 1f);
            previewAtkBar.transform.DOScale(new Vector3(previewAtk, 1, 0), 1f);
            previewSpeedBar.transform.DOScale(new Vector3(previewSpeed, 1, 0), 1f);
        }
    }
}