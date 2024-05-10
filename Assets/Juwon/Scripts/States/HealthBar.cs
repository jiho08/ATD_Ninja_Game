using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image hpBarImage;
    private float _maxHpValue = 100;
    private float _curHpValue = 100;
    [SerializeField] private HealthManager health;

    private void Start()
    {
        _maxHpValue = health.Health;
    }

    private void LateUpdate()
    {
        hpBarImage.fillAmount = health.Health / _maxHpValue; //healthManager에서 최대체력과 현재 체력 넣기
    }
}
