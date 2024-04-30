using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/UnitDatas")]
public class UnitDataSO : ScriptableObject
{
    public int TrainID;
    public Sprite TrainFront; //기차 앞부분
    public Sprite TrainBack; //기차 추가된 부분
    public string TrainName;
    public string TrainDesc;
    public string TrainRole;
    public int level;
    public int length;
    public float Hp;
    public float Atk;
    public float Speed;
}
