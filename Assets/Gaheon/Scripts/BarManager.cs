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

    float barHeight;
    
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

        currentHpBar.rectTransform.sizeDelta = new Vector2(currentHp * 6.4f, barHeight);
        currentAtkBar.rectTransform.sizeDelta = new Vector2(currentAtk * 32, barHeight);
        currentSpeedBar.rectTransform.sizeDelta = new Vector2(currentSpeed * 64, barHeight);
    }
}
