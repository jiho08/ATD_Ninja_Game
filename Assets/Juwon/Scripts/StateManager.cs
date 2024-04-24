using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public static StateManager Instance;
    [SerializeField] UnitStats[] _unitST;

    private void Awake() 
    {
        Instance = this;
    }
    private void Start() 
    {
        DontDestroyOnLoad(gameObject);
    }

     //체력 설정
    public void SetUnitHP(int value, float hp)
    {
        _unitST[value].health = hp;
    }
    public float GetUnitHP(int value)
    {
        return _unitST[value].health;
    }

    //속도 설정
    public void SetUnitSP(int value, float sp)
    {
        _unitST[value].speed = sp;
    }
    public float GetUnitSp(int value)
    {
        return _unitST[value].speed;
    }

    //공격력 설정
    public void SetUnitAtk(int value, float atk)
    {
        _unitST[value].atk = atk;
    }
    public float GetUnitAtk(int value)
    {
        return _unitST[value].atk;
    }

}

[Serializable]
public class UnitStats
{
    public float health = 100f; //체력
    public float speed = 10f; //속도
    public float atk = 20f; //공격력
    public float coolTime = 10f; //쿨타임
}
