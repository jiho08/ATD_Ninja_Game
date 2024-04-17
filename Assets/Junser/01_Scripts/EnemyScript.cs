using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float _MaxHp = 5;
    private float _CurrentHpPoint;
    //HP관련 변수

    [SerializeField]
    private float _AttackSpeed;
    public float Accelation;
    [SerializeField]
    private float DefaltAcclation;
    //이동 관련 변수


    [SerializeField]
    private GameObject _AttackCollision;
    private Rigidbody2D _Rigid;
    //컴포넌트 받아와야하는것들

    private bool _isDealay;
    [SerializeField]
    private float _DealayTime;
    //코루틴

    private void Awake()
    {
        _CurrentHpPoint = _MaxHp;

        _Rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float _speed = _Rigid.velocity.x;

        if (_speed < _AttackSpeed)
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
        _Rigid.velocity = new Vector2(1, 0) * Accelation;
    }

    public void TakeDamage(float _GetDamage)
    {
        _CurrentHpPoint -= _GetDamage;
        GetCoroutine();


        Debug.Log("피격");

        if (_CurrentHpPoint <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void GetCoroutine()
    {
        StartCoroutine(AttackDealy());
    }

    IEnumerator AttackDealy()
    {
        yield return new WaitForSecondsRealtime(0.1f);



        Accelation = -DefaltAcclation;
        yield return new WaitForSecondsRealtime(_DealayTime);


        Accelation = DefaltAcclation;
    }
}
