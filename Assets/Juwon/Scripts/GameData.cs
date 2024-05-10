using System;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable] // 직렬화

public class Data
{
    [Header("#GetStageNum")]
    public bool[] isOpenStage;
    public bool isTutorial;
    
    [Header("#UnitData")]
    public int[] level = new int[3];
    public int[] length = new int[3];
    public float[] hp = new float[3];
    public float[] atk = new float[3];
    public float[] speed = new float[3];
    
    [Header("#OwningUnit")]
    public bool owningKtx;
    public bool owningMgh;
    public bool owningLine1;
    
    
}