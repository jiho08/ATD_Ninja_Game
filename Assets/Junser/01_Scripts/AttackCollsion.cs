using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollsion : MonoBehaviour
{

    public float _damage = 1;
    private PlayerUnit _playerUnit;

    private HealthManager _playerHealth;
    private PoolManager _poolM;
    private void Awake()
    {
        _playerUnit = GetComponentInParent<PlayerUnit>();
    }
    private void OnEnable()
    {
        _playerUnit._playerHealth.OnDamage += HandleDamageChanger;
    }

    private void HandleDamageChanger(float value)
    {
        _damage = value;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {

            _playerHealth = collision.gameObject.GetComponent<HealthManager>();

            EnemyScript _enemy = collision.gameObject.GetComponent<EnemyScript>();

            
            if (collision.tag == "Enemy")
            {
                _playerHealth.Health = _playerHealth.Health - _damage;

                _enemy.TakeDamage();

                _playerUnit.Dealy();
            }
            else if (_playerHealth.isOnEntity[2])
            {
                _playerHealth.Health = _playerHealth.Health - _damage;
                _playerUnit.Dealy();

            }
        }


    }
}
