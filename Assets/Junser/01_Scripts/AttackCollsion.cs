using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AttackCollsion : MonoBehaviour
{
    public float damage;
    private PlayerUnit _playerUnit;
    private bool _canAttack = true;

    public event Action AttackEvent;

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

            HealthManager _playerHealth = collision.gameObject.GetComponent<HealthManager>();
            
            EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();

            Debug.Log(_canAttack);
   AttackEvent?.Invoke();
            if (_canAttack)
            {
          
                StartCoroutine(Dealay());
                if (_playerHealth.isOnEntity[1])
                {
                    
                    _playerHealth.Health -= damage;

                    _playerUnit.Dealy();

                    enemy.TakeDamage();
                    AudioManager.Instance.PlaySfx(AudioManager.Sfx.Hit);

                    
                }
                else if (_playerHealth.isOnEntity[2])
                {
                    AudioManager.Instance.PlaySfx(AudioManager.Sfx.Tower);
                    _playerHealth.Health -= damage;
                    _playerUnit.Dealy();
                    StartCoroutine(Dealay());

                }
           
        }
    }

    public IEnumerator Dealay()
    {
        _canAttack = false;
        yield return new WaitForSeconds(0.02f);
        try
        {
            _canAttack = true;
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error setting _canAttack to true: " + e.Message);
        }

    }


}


