using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailScript : MonoBehaviour
{
    private PlayerUnit _unit;
    private Rigidbody2D _rigid;
    private TrailRenderer _tail;


    private void Awake()
    {
        _rigid = GetComponentInParent<Rigidbody2D>();
        _unit = GetComponentInParent<PlayerUnit>();
        _tail = GetComponent<TrailRenderer>();
    }
    void Start()
    {
        transform.position = new Vector3(transform.position.x + _unit.GetTrainLength() * -2 -1, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        _tail.enabled = _rigid.velocity.x > _unit.GetTrainAttackSpeed();
    }
}
