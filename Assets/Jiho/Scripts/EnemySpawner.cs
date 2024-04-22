using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject _enemyPrefab; // �� ������
    [SerializeField] float _spawnTime; // �� ���� �ֱ�

    private void Awake()
    {
        // �� ���� �ڷ�ƾ �Լ� ȣ��
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
