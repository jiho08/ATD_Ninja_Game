using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubwayMovement : MonoBehaviour
{
    [SerializeField] float _speed = 10f;
    [SerializeField] float _scrollRange = 50f;
    [SerializeField] float _angle = -45f;
    [SerializeField] Transform _target;
    Rigidbody2D _rigid;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        _rigid.velocity = new Vector2(_speed, 0).normalized;

        if (transform.position.x >= _scrollRange)
        {
            transform.position = _target.position + Vector3.left * _scrollRange;
        }

        if (transform.position.x >= 115)
        {
            transform.rotation = Quaternion.AngleAxis(_angle, Vector3.forward);
            _rigid.velocity = new Vector2(_speed, -30);
        }
        if (transform.position.x < 115)
        {
            transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
            _rigid.velocity = new Vector2(_speed, 0);
        }
    }
}
