using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="SO/Enemy/StageSpawn")]
public class EnemySpawnSO : ScriptableObject
{
    public List<EnemySpawn> enemySpawns;
}

[Serializable]
public class EnemySpawn
{
    public float delay;
    public string type;
    public int point;
}