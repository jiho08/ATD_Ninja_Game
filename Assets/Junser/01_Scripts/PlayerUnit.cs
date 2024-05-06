using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : MonoBehaviour
{
    //HP관련 변수

    [SerializeField]
    private float _damage;
    public float _GetDamage { get { return _damage; } }


    [SerializeField]
    private float _AttackSpeed;
    private float Accelation;
    [SerializeField]
    private float _accel;


    public float _maxSpeed;

    //열차 길이

    [SerializeField]
    private int _trainLength;

    //이동 관련 변수


    [SerializeField]
    private GameObject _AttackCollision;
    private Rigidbody2D _Rigid;
    private Firsttrain _firstTrain;
    private HealthManager _playerHealth;
    //컴포넌트 받아와야하는것들

    public float _DealayTime;
    float _speed;
    //코루틴

    [SerializeField]
    private GameObject _train;

    private void Awake()
    {
        //컴포넌트 받는 부분
        _Rigid = GetComponent<Rigidbody2D>();
        _firstTrain = GetComponentInChildren<Firsttrain>();
        _playerHealth = GetComponent<HealthManager>();
    }

    private void Start()
    {


        _speed = 0;
        Accelation = _maxSpeed;
        //열차 길이 설정
        for (int i = 1; i <= _trainLength; i++)
        {
            GameObject _Line = Instantiate(_train);
            _Line.transform.SetParent(transform, false);
            _Line.transform.position = transform.position + new Vector3((i * -2f), 0);
        }
    }

    private void Update()
    {
        //현재 속도

        //이동 속도 제한
        _AttackCollision.gameObject.SetActive(_Rigid.velocity.x > _AttackSpeed);

        if (_playerHealth.Health < 0)
        {
            StopAllCoroutines();
        }

    }
    private void FixedUpdate()
    {
        _speed += 0.0001f;
        _accel = Mathf.Lerp(_accel, Accelation, _speed);
        //이동
        _Rigid.velocity = new Vector2(1, 0) * _accel;
    }

    public void TakeDamage()//피격 메서드
    {
        StartCoroutine("BackAway");

        _firstTrain.HitBehave();
    }

    public void Dealy()//공격 딜레이
    {
        StartCoroutine(AttackDealy());
    }

    IEnumerator BackAway()//피격 행동 코루틴
    {
        _accel = 0;
        yield return new WaitForSecondsRealtime(0.1f);

        Accelation = -_maxSpeed * 2;

        _AttackCollision.gameObject.SetActive(false);


        yield return new WaitForSecondsRealtime(_DealayTime);

        Accelation = _maxSpeed;
        _accel = 0;

        _speed = 0;

    }

    IEnumerator AttackDealy()// 공격 딜레이 코루틴
    {
        _accel = 0;

        yield return new WaitForSecondsRealtime(0.1f);


        Accelation = -_maxSpeed;

        yield return new WaitForSecondsRealtime(_DealayTime);

        _AttackCollision.gameObject.SetActive(true);

        Accelation = _maxSpeed;
        _speed = 0;

    }
}
