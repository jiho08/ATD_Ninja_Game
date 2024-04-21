using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovemate : MonoBehaviour
{
    private Rigidbody2D rigid;
    public float Movespeed;

    public bool onRail;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
         rigid.velocity = Vector3.right * Movespeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.)
    }
}
