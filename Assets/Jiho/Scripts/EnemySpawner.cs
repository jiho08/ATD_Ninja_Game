using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject _enemyPrefab; // �� ������
    [SerializeField] float _spawnTime; // �� ���� �ֱ�
    [SerializeField] Transform[] _wayPoints; // ���� ���������� �̵� ���

    private void Awake()
    {
        // �� ���� �ڷ�ƾ �Լ� ȣ��
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
