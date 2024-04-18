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

    private void Awake()
    {
        _playerUnit = GetComponentInParent<PlayerUnit>();

    }

    void FixedUpdate()
    {
        transform.position += Vector3.right * _fireSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null&& collision.tag == "Enemy")
        {
            EnemyScript player = collision.gameObject.GetComponent<EnemyScript>();

            if(player != null && collision != null)
            {
                player.TakeDamage(_damage);
            }
        }
    }
}
