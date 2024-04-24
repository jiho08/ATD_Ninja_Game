using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackCollider : MonoBehaviour
{
    public float _damage = 1;
    private EnemyScript _enemy;
    private HealthManager _playerHealth;

    private void Awake()
    {
        _enemy = GetComponentInParent<EnemyScript>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null && collision.tag == "Player")
        {
            _playerHealth = collision.gameObject.GetComponent<HealthManager>();

            PlayerUnit player = collision.gameObject.GetComponent<PlayerUnit>();

            if(player != null)
            {
                _playerHealth.Health = _playerHealth.Health - _damage;

                player.GetCoroutine();
                _enemy.GetCoroutine();
            }
        }
    }
}
