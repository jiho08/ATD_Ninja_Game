using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubwayMovement : MonoBehaviour
{
    [SerializeField] float _speed = 10f;
    [SerializeField] float _scrollRange = 50f;
    [SerializeField] Transform target;
    Rigidbody2D _rigid;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        _rigid.velocity = new Vector2(_speed, 0);

        if (transform.position.x >= _scrollRange)
        {
            transform.position = target.position + Vector3.left * _scrollRange;
        }
    }
}
