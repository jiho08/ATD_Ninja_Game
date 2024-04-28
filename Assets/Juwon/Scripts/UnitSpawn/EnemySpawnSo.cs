using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="SO/Enemy/StageSpawn")]
public class EnemySpawnSo : ScriptableObject
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