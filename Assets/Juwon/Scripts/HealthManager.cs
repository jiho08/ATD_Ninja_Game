using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    //Hp가 들어가는 유닛에 넣기

    private float maxHealth = 10f;
    [SerializeField] private float curHealth;

    private void Start() 
    {
        curHealth = maxHealth;
    }

    public float GetHp()
    {
        return curHealth;
    }
    public void SetHp(float value)
    {
        curHealth = value;
    }

    public void Damage(float value)
    {
        curHealth -= value;
    }

    //자신의 HP가 0이라면 비활성화
}
