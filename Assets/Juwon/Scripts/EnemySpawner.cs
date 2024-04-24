using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] SpawnManager spawnM;
    [SerializeField] GetSpawnEnemy getSpawn;

    [SerializeField] int stageNum = 0;
    int stageEnemyCount = 0;
    public Coroutine runningCoroutine = null;


    private void Start() 
    {
        //원하는 유닛의 생성수 제한
        switch (stageNum){
            case 1:
                spawnM.SetDefaultCounts(0, 10);
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
        getSpawn.ReadSpawn(stageNum-1); //스테이지에 맞는 txt읽기
        runningCoroutine = StartCoroutine("StartStage"); //스테이지 시작
    }

    private int typeToInt(string str) //type을 int로 변환하여 전송
    {
        switch(str) {
            case "M":
                return 0;
        }
        return 0;
    }

    IEnumerator StartStage()
    {
        yield return new WaitForSeconds(getSpawn.GetSpawnsList()[stageEnemyCount].delay); //적 생성 딜레이
        spawnM.EnemySpawn(typeToInt(getSpawn.GetSpawnsList()[stageEnemyCount].type), getSpawn.GetSpawnsList()[stageEnemyCount].point); //적 생성

        stageEnemyCount++; 

        //스테이지에 적의 수가 넘으면 멈추기
        if(getSpawn.GetSpawnsList().Count <= stageEnemyCount) {
            stageEnemyCount = 0;
            StopCoroutine(runningCoroutine);
        }
        else {
            StartCoroutine(StartStage());
        }
    }
}
