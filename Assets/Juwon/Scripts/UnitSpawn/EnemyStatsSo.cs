using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Enemy/Data")]
public class EnemyStatsSo : ScriptableObject
{
    public Stats[] enemysData;
}

[Serializable]
public class Stats
{
    public float hp;
    public float atk;
    public float speed;
}
