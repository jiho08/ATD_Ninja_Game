using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackCollider : MonoBehaviour
{
    public float _damage = 1;
    private EnemyScript enemy;

    private void Awake()
    {
        enemy = GetComponentInParent<EnemyScript>();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PlayerUnit player = collision.gameObject.GetComponent<PlayerUnit>();

            player.TakeDamage(_damage);
            enemy.GetCoroutine();
        }
    }
}
