using System.Collections.Generic;
using UnityEngine;

public class GetSpawnEnemy : MonoBehaviour
{
    private List<EnemySpawn> _spawnsL;
    [SerializeField] private EnemySpawnSo[] spawnsSo;

    private void Awake()
    {
        _spawnsL = new List<EnemySpawn>();
    }

    public void ReadSpawn(int value)
    {
        _spawnsL.Clear();

        _spawnsL = spawnsSo[value].enemySpawns;
    }

    //리스트 보네기
    public List<EnemySpawn> GetSpawnsList()
    {
        return _spawnsL;
    }
}