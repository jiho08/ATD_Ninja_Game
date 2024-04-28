using System;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public static StateManager Instance;
    [SerializeField] UnitStats[] unitSt;

    private void Awake() 
    {
        Instance = this;
    }
    private void Start() 
    {
        DontDestroyOnLoad(gameObject);
    }

     //체력 설정
    public void SetUnitHp(int value, float hp)
    {
        unitSt[value].health = hp;
    }
    public float GetUnitHp(int value)
    {
        return unitSt[value].health;
    }

    //속도 설정
    public void SetUnitSp(int value, float sp)
    {
        unitSt[value].speed = sp;
    }
    public float GetUnitSp(int value)
    {
        return unitSt[value].speed;
    }

    //공격력 설정
    public void SetUnitAtk(int value, float atk)
    {
        unitSt[value].atk = atk;
    }
    public float GetUnitAtk(int value)
    {
        return unitSt[value].atk;
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
