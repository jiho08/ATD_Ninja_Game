using System.Collections;
using System.Collections.Generic;
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

    float barHeight;

    void Start()
    {
        barHeight = currentHpBar.rectTransform.sizeDelta.y;
    }


    public void ChangeBar()
    {
        currentHp = selectManager.selectedSO.Hp;
        currentAtk = selectManager.selectedSO.Atk;
        currentSpeed = selectManager.selectedSO.Speed;
        currentLv = selectManager.selectedSO.level;

        currentHpBar.rectTransform.sizeDelta = new Vector2(currentHp * 6.4f, barHeight);
        currentAtkBar.rectTransform.sizeDelta = new Vector2(currentAtk * 32, barHeight);
        currentSpeedBar.rectTransform.sizeDelta = new Vector2(currentSpeed * 64, barHeight);

        if (currentLv < 5)
        {

            previewHp = selectManager.selectedUnitLevel.Hp[currentLv];
            previewAtk = selectManager.selectedUnitLevel.Atk[currentLv];
            previewSpeed = selectManager.selectedUnitLevel.Speed[currentLv];

            previewHpBar.rectTransform.sizeDelta = new Vector2(previewHp * 6.4f, barHeight);
            previewAtkBar.rectTransform.sizeDelta = new Vector2(previewAtk * 32, barHeight);
            previewSpeedBar.rectTransform.sizeDelta = new Vector2(previewSpeed * 64, barHeight);
        }
    }
}
