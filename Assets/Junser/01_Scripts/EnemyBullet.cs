using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField]
    private float _fireSpeed;
    [SerializeField]
    private float _damage;
    private PlayerUnit _playerUnit;
    private HealthManager _playerHealth;

    private void Awake()
    {
        _playerUnit = GetComponentInParent<PlayerUnit>();

    }

    void FixedUpdate()
    {
        transform.position += Vector3.left * _fireSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.tag == "Player")
        {
            PlayerUnit _enemy = collision.gameObject.GetComponent<PlayerUnit>();
            _playerHealth = collision.gameObject.GetComponent<HealthManager>();


            if (_enemy != null)
            {
                _playerHealth.Health = _playerHealth.Health - _damage;
                _enemy.TakeDamage();
                gameObject.SetActive(false);
            }
        }
    }
}
