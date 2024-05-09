using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : MonoBehaviour
{
    //HP관련 변수

    [SerializeField]
    private float _damage;
    public float _GetDamage { get; private set; }


    [SerializeField]
    private float _AttackSpeed;
    [SerializeField]
    private float _accel;

    private bool _rearground;

    public float _maxSpeed;

    //열차 길이

    [SerializeField]
    private int _trainLength;

    //이동 관련 변수
    float time = 0;

    [SerializeField]
    private GameObject _AttackCollision;
    private Rigidbody2D _Rigid;
    private Firsttrain _firstTrain;
    public HealthManager _playerHealth;
    private ParticleSystem _particle;
    private BoxCollider2D _hitBox;

    //컴포넌트 받아와야하는것들

    public float _DealayTime;
    float _speed;

    public float _defaltYPos;
    //코루틴

    [SerializeField]
    private GameObject _train;

    private void Awake()
    {
        //컴포넌트 받는 부분
        _Rigid = GetComponent<Rigidbody2D>();
        _firstTrain = GetComponentInChildren<Firsttrain>();
        _playerHealth = GetComponent<HealthManager>();
        _particle = GetComponentInChildren<ParticleSystem>();
        _hitBox = GetComponent<BoxCollider2D>();
    }


    /*private void Start()
    {
        _defaltYPos = transform.position.y;

        _speed = 0;
        Accelation = _maxSpeed;
        //열차 길이 설정
        for (int i = 1; i <= _trainLength; i++)
        {
            GameObject _Line = Instantiate(_train);
            _Line.transform.SetParent(transform, false);
            _Line.transform.position = transform.position + new Vector3((i * -2f), 0);
        }
    }*/

    private void OnEnable()
    {
        _defaltYPos = transform.position.y;

        _speed = 0;
        //열차 길이 설정
        for (int i = 1; i <= _trainLength; i++)
        {
            GameObject _Line = Instantiate(_train);
            _Line.transform.SetParent(transform, false);
            _Line.transform.position = transform.position + new Vector3((i * -2f), 0);
        }
    }

    private void OnDisable()
    {

        _rearground = false;
        _speed = 0;
        _accel = 0;

        StopCoroutine("AttackDealy");
        StopCoroutine("BackAway");
    }

    private void Update()
    {
        //현재 속도

        //이동 속도 제한
        _AttackCollision.gameObject.SetActive(_Rigid.velocity.x > _AttackSpeed);

        

    }
    private void FixedUpdate()
    {
        if (!_rearground)
        {
            _speed = 0.05f;
            _accel = Mathf.Lerp(_accel, _maxSpeed, _speed);
            //이동
            _Rigid.velocity = new Vector2(1, 0) * _accel;
        }
        else
        {
            
            time += 0.05f;

            _accel = _maxSpeed - time*_maxSpeed/_DealayTime / 3;
            //이동
            _Rigid.velocity = new Vector2(-1, 0) * _accel;
        }
    }

    public int GetTrainLength()
    {
        return _trainLength;
    }

    public float GetTrainAttackSpeed()
    {
        return _AttackSpeed;
    }

    public void TakeDamage()//피격 메서드
    {
        if (this.gameObject.activeSelf)
        {
            _particle.Play();
            StartCoroutine("BackAway");
            _firstTrain.HitBehave();
        }

    }

    public void Dealy()//공격 딜레이
    {
        if (this.gameObject.activeSelf)
        {
            StartCoroutine(AttackDealy());
        }
    }

    IEnumerator BackAway()//피격 행동 코루틴
    {
        time = 0;
        _rearground = true;
        _hitBox.enabled = false;

        _accel = 0;


        _AttackCollision.gameObject.SetActive(false);



        yield return new WaitForSeconds(_DealayTime);

        
        _accel = 0;

        _speed = 0;
        _hitBox.enabled = true;
        _rearground = false;


    }

    IEnumerator AttackDealy()// 공격 딜레이 코루틴
    {
        _rearground = true;

        _accel = 0;

        time = 0;


        yield return new WaitForSeconds(_DealayTime);

        _AttackCollision.gameObject.SetActive(true);

        _accel = 0;
        _speed = 0;
        _rearground = false;

    }
}
