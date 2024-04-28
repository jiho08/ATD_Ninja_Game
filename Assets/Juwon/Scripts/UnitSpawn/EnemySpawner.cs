using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private SpawnManager spawnM;
    [SerializeField] private GetSpawnEnemy getSpawn;

    [SerializeField] private GetStageNumberSo getStageNumSo;

    [SerializeField] private int getStageCount;
    private int _stageEnemyCount;
    private Coroutine _runningCoroutine;


    private void Start()
    {

        getStageCount = getStageNumSo.stageNumber;
        //원하는 유닛의 생성수 제한
        switch (getStageCount){
            case 1:
                spawnM.SetDefaultCounts(0, 10);
                spawnM.SetDefaultCounts(1, 10);
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
        }
        getSpawn.ReadSpawn(getStageCount-1); //스테이지에 맞는 Stage읽기
        _runningCoroutine = StartCoroutine(StartStage()); //스테이지 시작
    }

    private int TypeToInt(string str) //type을 int로 변환하여 전송
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
    }
}
