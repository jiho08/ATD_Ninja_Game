using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackCollider : MonoBehaviour
{
    [SerializeField] private float _damage;
    private EnemyScript _enemy;
    private HealthManager _playerHealth;
    private ParticleSystem _particle;

    private void Awake()
    {
        
        _enemy = GetComponentInParent<EnemyScript>();
    }

    private void Start()
    {
        _damage = _enemy._GetDamage;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null && collision.CompareTag("Player"))
        {
            _playerHealth = collision.gameObject.GetComponent<HealthManager>();

            PlayerUnit player = collision.gameObject.GetComponent<PlayerUnit>();

            if(_playerHealth.isOnEntity[0])
            {
                _playerHealth.Health -= _damage;

                player.TakeDamage();
                _enemy.Dealy();
            }
            else if (_playerHealth.isOnEntity[2])
            {
                _playerHealth.Health -= _damage;
                _enemy.Dealy();

            }
        }
    }
}

