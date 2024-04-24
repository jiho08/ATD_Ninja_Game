using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarManager : MonoBehaviour
{
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

    private void Awake()
    {
    }
    void Start()
    {
        barHeight = currentHpBar.rectTransform.sizeDelta.y;
    }

    void Update()
    {
        
    }

    public void ChangeBar()
    {
        currentHp = SelectManager.selectInstance.selectedSO.Hp;
        currentAtk = SelectManager.selectInstance.selectedSO.Atk;
        currentSpeed = SelectManager.selectInstance.selectedSO.Speed;
        currentLv = SelectManager.selectInstance.selectedSO.level;

        currentHpBar.rectTransform.sizeDelta = new Vector2(currentHp * 6.4f, barHeight);
        currentAtkBar.rectTransform.sizeDelta = new Vector2(currentAtk * 32, barHeight);
        currentSpeedBar.rectTransform.sizeDelta = new Vector2(currentSpeed * 64, barHeight);

        previewHp = SelectManager.selectInstance.selectedUnitLevel.Hp[currentLv];
        previewAtk = SelectManager.selectInstance.selectedUnitLevel.Atk[currentLv];
        previewSpeed = SelectManager.selectInstance.selectedUnitLevel.Speed[currentLv];

        previewHpBar.rectTransform.sizeDelta = new Vector2(previewHp * 6.4f, barHeight);
        previewAtkBar.rectTransform.sizeDelta = new Vector2(previewAtk * 32, barHeight);
        previewSpeedBar.rectTransform.sizeDelta = new Vector2(previewSpeed * 64, barHeight);
    }
}
