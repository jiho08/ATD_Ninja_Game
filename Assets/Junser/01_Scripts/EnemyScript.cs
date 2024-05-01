using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //HP관련 변수

    [SerializeField]
    private float _AttackSpeed;
    public float Accelation;
    [SerializeField]
    private float DefaltAcclation;
    //이동 관련 변수
    [SerializeField]
    private float _damage;
    public float _GetDamage { get { return _damage; } set { _damage = value; } }

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
        //컴포넌트 받기
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

    public void TakeDamage()
    {
        StartCoroutine(BackAway());
    }
    public void Dealy()
    {
        StartCoroutine(AttackDealy());
    }
    IEnumerator BackAway()
    {
        yield return new WaitForSecondsRealtime(0.1f);

        transform.rotation = Quaternion.Euler(0, 0, -35);
        transform.position += new Vector3(0, 0.53522833687f);


        Accelation = -DefaltAcclation*2;
        yield return new WaitForSecondsRealtime(_DealayTime);

        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.position -= new Vector3(0, 0.53522833687f);


        Accelation = DefaltAcclation;
    }

    IEnumerator AttackDealy()
    {
        yield return new WaitForSecondsRealtime(0.1f);

        Accelation = -DefaltAcclation * 2;


        yield return new WaitForSecondsRealtime(_DealayTime);
        Accelation = DefaltAcclation;


    }
}
