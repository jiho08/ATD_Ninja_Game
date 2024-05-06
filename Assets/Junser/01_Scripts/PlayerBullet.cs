using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField]
    private float _fireSpeed;
    [SerializeField]
    private float _damage;
    private PlayerUnit _playerUnit;
    private HealthManager _playerHealth;

    private void Awake()
    {
    }
    private void Start()
    {
        _playerUnit = GetComponentInParent<PlayerUnit>();
        _damage = _playerUnit._GetDamage;
    }

    void FixedUpdate()
    {
        transform.position += Vector3.right * _fireSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null&& collision.tag == "Enemy")
        {
            EnemyScript _enemy = collision.gameObject.GetComponent<EnemyScript>();
            _playerHealth = collision.gameObject.GetComponent<HealthManager>();


            if (_enemy != null)
            {
                _playerHealth.Health = _playerHealth.Health - _playerHealth.Damage;
                if (_enemy != null)
                {
                    _enemy.TakeDamage();
                    gameObject.SetActive(false);
                }

            }
        }
    }
}
