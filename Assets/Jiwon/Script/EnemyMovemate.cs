using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovemate : MonoBehaviour
{
    private Rigidbody2D rigid;
    public float Movespeed;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
         rigid.velocity = Vector3.right * Movespeed;
    }

    
}
