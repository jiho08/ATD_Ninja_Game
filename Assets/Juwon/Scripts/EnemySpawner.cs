using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] PoolManager enemyPool;

    [SerializeField] int stageNum;

    /* private float createTime = 0;
    private float currentTime = 0;
    private float minTime = 4f;
    private float maxTime = 10f; */


    private void Start() 
    {
        //createTime = Random.Range(minTime, maxTime);
        if(stageNum == 1) {
            FirstStage();
        }
        else if(stageNum == 2) {

        }
        else if(stageNum == 3) {
            
        }
        else if(stageNum == 4) {
            
        }
        else if(stageNum == 5) {
            
        }
        else {
            
        }
    }
    private void Update()
    {
        //랜덤
        /* currentTime += Time.deltaTime;
        if(currentTime > createTime) {
            enemyPool.Get(0); //Random.Range(0, 4);


            currentTime = 0;
            createTime = Random.Range(minTime, maxTime);
        } */
    }

    IEnumerator FirstStage()
    {
        yield return new WaitForSeconds(1);

        //적 원하는데로 생성
    }
}
