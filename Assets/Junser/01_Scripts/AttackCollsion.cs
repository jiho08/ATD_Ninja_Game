using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AttackCollsion : MonoBehaviour
{
    public float damage;
    private PlayerUnit _playerUnit;
    private HealthManager _playerHealth;

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
        damage = value;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            _playerHealth = collision.gameObject.GetComponent<HealthManager>();
            
            EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();

            if (_playerHealth.isOnEntity[1])
            {
                AudioManager.Instance.PlaySfx(AudioManager.Sfx.Hit);
                _playerHealth.Health -= damage;
            
                enemy.TakeDamage();
            
                _playerUnit.Dealy();
            
            
            }
            else if (_playerHealth.isOnEntity[2])
            {
                AudioManager.Instance.PlaySfx(AudioManager.Sfx.Tower);
                _playerHealth.Health -= damage;
                _playerUnit.Dealy();
            }
        }
    }
}
