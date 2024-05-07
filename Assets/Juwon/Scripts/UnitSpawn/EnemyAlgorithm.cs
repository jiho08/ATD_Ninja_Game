using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyAlgorithm : MonoBehaviour
{
    private SpawnManager _spawnM;
    private HealthManager _enemyHealth;

    private List<GameObject>[] _enemyList;
    [SerializeField] private GetStageNumberSo getStageNumSo;
    
    private int[] _maxSpawnCount = new int[6];
    private int[] _setSpawnCounts = new int[6];

    private IEnumerator _spawnCoolCoru;
    private IEnumerator _inCoolCoru;
    private int _stageNum;
    private int _enemyNum;
    
    private float _timer;
    private float _coolTimer;
    
    private void Start()
    {
        _spawnM = FindObjectOfType<SpawnManager>();
        _stageNum = getStageNumSo.stageNumber;
        
        //생성 최대 수 제한
        switch (_stageNum){
            case 0:
                _maxSpawnCount[0] = 7;
                break;
            case 1:
                _maxSpawnCount[0] = 15;
                break;
            case 2:
                _maxSpawnCount[0] = 20;
                _maxSpawnCount[1] = 10;
                break;
            case 3:
                _maxSpawnCount[0] = 25;
                _maxSpawnCount[1] = 10;
                _maxSpawnCount[2] = 5;
                break;
            case 4:
                break;
            case 5:
                break;
        }
        
        _enemyList = new List<GameObject>[_maxSpawnCount.Length];

        for (int i = 0; i < _enemyList.Length; i++) {
            _enemyList[i] = new List<GameObject>();
        }

        SpawnAI();
        //_timer = Random.Range(0f, 5f);
        _timer = 1;
    }

    private void Update()
    {
        if (_setSpawnCounts[_enemyNum] >= _maxSpawnCount[_enemyNum]) return;
        
        _coolTimer += Time.deltaTime;
        
        if (_coolTimer > _timer)
        {
            SpawnAI();

            _coolTimer = 0;
            _timer = 1;
        }
    }

    private void SpawnAI()
    {
        int rand = Random.Range(0, 3);

        if (rand < 2)
        {
            if (_stageNum == 0) _stageNum = 1;
            
            rand = Random.Range(0, _stageNum);
            _enemyNum = rand;

            if (_setSpawnCounts[rand] < _maxSpawnCount[rand])
            {
                GameObject enemy = _spawnM.EnemySpawn(rand, Random.Range(1, 4));
                
                _setSpawnCounts[rand]++;

                _enemyHealth = enemy.GetComponent<HealthManager>();
                _enemyHealth.OnEnemyRepairCool += HandleRepairCoolTime;
                
                foreach (GameObject item in _enemyList[_enemyNum])
                {
                    if (item == enemy)
                    {
                        return;
                    }
                }
                _enemyList[_enemyNum].Add(enemy);
            }
        }

        /*if (_setSpawnCounts[_enemyNum] < _maxSpawnCount[_enemyNum])
        {
            Debug.Log("in");
            _spawnCoolCoru = StartCoroutine(SpawnCool());
        }*/
    }

    /*private IEnumerator SpawnCool()
    {
        //yield return new WaitForSeconds(Random.Range(0f, 5f));
        yield return new WaitForSeconds(1f);
        SpawnAI();
        StopCoroutine(_spawnCoolCoru);
    }*/
    
    private void HandleRepairCoolTime(int value)
    {
        _enemyHealth.OnEnemyRepairCool -= HandleRepairCoolTime;
        _inCoolCoru = EnemyCool(value);
        
        foreach (GameObject item in _enemyList[value])
        {
            if (!item.activeSelf) continue;
            
            StartCoroutine(_inCoolCoru);
            break;
        }
    }
    
    private IEnumerator EnemyCool(int value)
    {
        yield return new WaitForSeconds(10f);
        _setSpawnCounts[value]--;
        StopCoroutine(_inCoolCoru);
    }
}