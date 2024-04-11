using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : MonoBehaviour
{
    public float _MaxHp = 5;
    private float _CurrentHpPoint;
    [SerializeField]
    private float _AttackSpeed;
    private Rigidbody2D _Rigid;
    [SerializeField]
    private GameObject _AttackCollision;
    public float _MaxSpeed;
    public float Accelation;
    private void Awake()
    {
        _CurrentHpPoint = _MaxHp;

        _Rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float _speed = Mathf.Abs(_Rigid.velocity.x);

        if (_speed > _AttackSpeed)
        {
            _AttackCollision.SetActive(true);
        }
        else
        {
            _AttackCollision.SetActive(false);
        }

    }
    private void FixedUpdate()
    {
        if (_Rigid.velocity.x < _MaxSpeed)
        {
            _Rigid.velocity += new Vector2(1,0) * Accelation;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.tag == "Enemy")
        {
            EnemyScript _enemy = other.gameObject.GetComponent<EnemyScript>();

            TakeDamage(_enemy._damage);
        }
    }

    
    private void TakeDamage(float _GetDamage)
    {
        _CurrentHpPoint -= _GetDamage;

        if(_CurrentHpPoint <= 0)
        {
            //»ç¸Á
        }
    }
}
