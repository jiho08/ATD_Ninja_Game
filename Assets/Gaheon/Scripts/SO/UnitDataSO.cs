using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/UnitDatas")]
public class UnitDataSO : ScriptableObject
{
    public int TrainID;
    public Sprite TrainFront; //���� �պκ�
    public Sprite TrainBack; //���� �߰��� �κ�
    public string TrainName;
    public string TrainDesc;
    public string TrainRole;
    public int level;
    public int length;
    public float Hp;
    public float Atk;
    public float Speed;
}
