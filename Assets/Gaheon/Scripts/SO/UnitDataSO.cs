using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

[CreateAssetMenu(menuName = "SO/Units/UnitDatas")]
public class UnitDataSO : ScriptableObject
{
    public int TrainID;
    public SpriteLibraryAsset TrainAnimation; //���� �պκ�
    public Sprite TrainHead; //���� �պκ�
    public Sprite TrainBody; //���� �߰��� �κ�
    public string TrainName;
    public string TrainDesc;
    public string TrainRole;
    public int level;
    public int length;
    public float Hp;
    public float Atk;
    public float Speed;
}
