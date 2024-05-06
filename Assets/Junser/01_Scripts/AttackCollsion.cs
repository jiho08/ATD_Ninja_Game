using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollsion : MonoBehaviour
{
    public float _damage = 1;
    private PlayerUnit _playerUnit;
    private HealthManager _playerHealth;
    private PoolManager _poolM;
    private ParticleSystem _particle;
    private void Awake()
    {
        _playerUnit = GetComponentInParent<PlayerUnit>();
        _particle = GetComponentInChildren<ParticleSystem>();

    }

    private void Start()
    {
        _damage = _playerUnit._GetDamage;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.tag == "Enemy")
        {
            _playerHealth = collision.gameObject.GetComponent<HealthManager>();

            EnemyScript _enemy = collision.gameObject.GetComponent<EnemyScript>();


            if (_playerUnit != null)
            {
                _playerHealth.Health = _playerHealth.Health - _playerHealth.Damage;
                _enemy.TakeDamage();

                _playerUnit.TakeDamage();
                _particle.Play();

            }
        }
    }
}
