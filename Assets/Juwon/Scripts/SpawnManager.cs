using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] PoolManager unitPool;
    [SerializeField] PoolManager enemyPool;

    [SerializeField] private Transform[] spawnPos; //스폰 위치 3개 관리
    
    private int[] defaultSpawnCounts = new int[10]; //유닛 수만큼 넣기 (0 : 무궁화, 1 : 무언가, 2 : 등등)
    private int[] getSpawnCounts = new int[10]; //소환된 유닛 수만큼 넣기 (0 : 무궁화, 1 : 무언가, 2 : 등등)


    [SerializeField] GameObject UnitSpawn(int value)
    {
        if(getSpawnCounts[value] > defaultSpawnCounts[value]) return null; //정해진 수보다 많아지면 리턴
        
        GameObject unit = unitPool.Get(value);
        unit.transform.position = spawnPos[0].position; //정해진 소환할 위치에 소환(우선 정함)
        unit.GetComponent<HealthManager>().SetHp(StateManager.Instance.GetUnitHP(value)); //HP설정

        getSpawnCounts[0]++;
        return unit;
    }

    [SerializeField] GameObject EnemySpawn(int value, Transform setPos)
    {
        GameObject enemy = enemyPool.Get(value);
        enemy.transform.position = setPos.position;
        return enemy;
    }

    public void SetDefaultCounts(int value, int count) //value의 번호에 유닛 제한수를 count로 제한
    {
        defaultSpawnCounts[value] = count;
    }
}
