using UnityEngine;
using System;


public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private SpawnManager spawnM;
    [SerializeField] private GetSpawnEnemy getSpawn;
    [SerializeField]private EnemyAlgorithm enemyAl;

    [SerializeField] private GetStageNumberSo getStageNumSo;

    public Action OnChange;

    [SerializeField] private int getStageCount;
    private int _stageEnemyCount;
    private Coroutine _runningCoroutine;
    

    private void Awake()
    {

        getStageCount = getStageNumSo.stageNumber;
        //원하는 유닛의 생성수 제한
        switch (getStageCount){
            case 0:
                spawnM.SetDefaultCounts(0, 10);
                break;
            case 1:
                spawnM.SetDefaultCounts(0, 10);
                spawnM.SetDefaultCounts(1, 5);
                break;
            case 2:
                spawnM.SetDefaultCounts(0, 10);
                spawnM.SetDefaultCounts(1, 5);
                spawnM.SetDefaultCounts(2, 3);
                break;
            default:
                spawnM.SetDefaultCounts(0, 10);
                spawnM.SetDefaultCounts(1, 5);
                spawnM.SetDefaultCounts(2, 3);
                break;
        }
        //getSpawn.ReadSpawn(getStageCount-1); //스테이지에 맞는 Stage읽기
        //_runningCoroutine = StartCoroutine(StartStage()); //스테이지 시작

    }

    private void Start()
    {
        OnChange?.Invoke();
    }

    //원하는 대로 생성 (지금은 알고리즘으로 돌려서 안씀)
    /*private int TypeToInt(string str) //type을 int로 변환하여 전송
    {
        switch(str) {
            case "M":
                return 0;
        }
        return 0;
    }

    IEnumerator StartStage()
    {
        yield return new WaitForSeconds(getSpawn.GetSpawnsList()[_stageEnemyCount].delay); //적 생성 딜레이
        spawnM.EnemySpawn(TypeToInt(getSpawn.GetSpawnsList()[_stageEnemyCount].type), getSpawn.GetSpawnsList()[_stageEnemyCount].point); //적 생성

        _stageEnemyCount++; 

        //스테이지에 적의 수가 넘으면 멈추기
        if(getSpawn.GetSpawnsList().Count <= _stageEnemyCount) {
            _stageEnemyCount = 0;
            StopCoroutine(_runningCoroutine);
        }
        else {
            StartCoroutine(StartStage());
        }
    }*/
}
