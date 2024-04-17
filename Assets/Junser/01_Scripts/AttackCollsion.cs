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
        if (collision.tag == "Enemy")
        {
            EnemyScript player = collision.gameObject.GetComponent<EnemyScript>();

            player.TakeDamage(_damage);
            player1.GetCoroutine();
        }
    }
}
