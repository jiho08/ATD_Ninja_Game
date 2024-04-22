using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject _enemyPrefab; // 利 橇府崎
    [SerializeField] float _spawnTime; // 利 积己 林扁

    private void Awake()
    {
        // 利 积己 内风凭 窃荐 龋免
        StartCoroutine("SpawnEnemy");
    }
    private void Update()
    {
        SpawnEnemy();
    }
    private IEnumerator SpawnEnemy()
    {
        GameObject clone = Instantiate(_enemyPrefab);
        Enemy _enemy = clone.GetComponent<Enemy>();
        yield return new WaitForSeconds(_spawnTime);
    }
}
