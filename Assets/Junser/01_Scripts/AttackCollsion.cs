using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollsion : MonoBehaviour
{
    public float _damage = 1;
    private PlayerUnit player1;

    private void Awake()
    {
        player1 = GetComponentInParent<PlayerUnit>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.tag == "Enemy")
        {
            EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();

            enemy.TakeDamage(_damage);
            player1.GetCoroutine();
        }
    }
}
