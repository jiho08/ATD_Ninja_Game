using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject _enemyPrefab; // 적 프리펩
    [SerializeField] float _spawnTime; // 적 생성 주기
    [SerializeField] Transform[] _wayPoints; // 현재 스테이지의 이동 경로

    private void Awake()
    {
        // 적 생성 코루틴 함수 호출
        StartCoroutine("SpawnEnemy");
    }
    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            GameObject clone = Instantiate(_enemyPrefab);
            Enemy _enemy = clone.GetComponent<Enemy>();
            _enemy.Setup(_wayPoints);
            yield return new WaitForSeconds(_spawnTime);
        }
    }
}
