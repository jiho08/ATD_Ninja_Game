using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private PoolManager unitPool;
    [SerializeField] private PoolManager enemyPool;

    [SerializeField] private UnitDataSO[] unitData; //유닛에 레벨에 맞게 스탯 가져오기

    //[SerializeField] private Transform[] unitSpawnPos; //스폰 위치 3개 관리
    [SerializeField] private Transform[] enemySpawnPos;

    private readonly int[] _defaultSpawnCounts = new int[10]; //유닛 수만큼 넣기 (0 : 무궁화, 1 : 무언가, 2 : 등등)
    private readonly int[] _getSpawnCounts = new int[10]; //소환된 유닛 수만큼 넣기 (0 : 무궁화, 1 : 무언가, 2 : 등등)

    //원하는 유닛과 위치 생성
    public GameObject UnitSpawn(int value)
    {
        if(_getSpawnCounts[value] > _defaultSpawnCounts[value]) return null; //정해진 수보다 많아지면 리턴
        
        GameObject unit = unitPool.Get(value);
        //unit.transform.position = unitSpawnPos[pos-1].position; //정해진 소환할 위치에 소환(우선 정함)
        HealthManager unitHealth = unit.GetComponent<HealthManager>(); //HP설정
        unitHealth.Health = unitData[value].Hp; //HP설정
        unitHealth.Damage = unitData[value].Atk; //데미지 설정
        //unit.GetComponent<PlayerUnit>().

        _getSpawnCounts[value]++;
        return unit;
    }

    //원하는 적과 위치 생성
    public GameObject EnemySpawn(int value, int pos)
    {
        GameObject enemy = enemyPool.Get(value);
        enemy.transform.position = enemySpawnPos[pos-1].position;
        return enemy;
    }

    public void SetDefaultCounts(int value, int count) //value의 번호에 유닛 제한수를 count로 제한
    {
        _defaultSpawnCounts[value] = count;
    }
}
