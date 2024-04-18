using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 0f;
    [SerializeField] Vector3 _moveDir = Vector3.zero;
    public float _MoveSpeed => _moveSpeed;

    private void Update()
    {
        transform.position += _moveSpeed * _moveDir * Time.deltaTime;
    }
    public void MoveTo(Vector3 _direction)
    {
        _moveDir = _direction;
    }
}
