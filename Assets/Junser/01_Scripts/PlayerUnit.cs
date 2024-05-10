using Baek.Utile;
using Cinemachine;
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

    public bool isMove;

    [SerializeField]
    private float _AttackSpeed;
    [SerializeField]
    private float _accel;

    private bool _rearground;
    public bool _canAttack;

    public float _maxSpeed;

    //열차 길이


    public int _trainLength;

    //이동 관련 변수
    float time = 0;

    [SerializeField]
    private GameObject _AttackCollision;
    private Rigidbody2D _Rigid;
    private Firsttrain _firstTrain;
    private ParticleSystem _particle;
    private BoxCollider2D _hitBox;

    public HealthManager _playerHealth;

    //컴포넌트 받아와야하는것들

    public float _DealayTime;
    float _speed;

    public float _defaltYPos;
    //코루틴

    [SerializeField]
    private GameObject _train;

    private List<GameObject> _lineList = new List<GameObject>();

    [SerializeField] private AttackCollsion _attackCollsion;
    private Transform _cam;


    private void Awake()
    {
        //컴포넌트 받는 부분
        _Rigid = GetComponent<Rigidbody2D>();
        _firstTrain = GetComponentInChildren<Firsttrain>();
        _playerHealth = GetComponent<HealthManager>();
        _particle = GetComponentInChildren<ParticleSystem>();
        _hitBox = GetComponent<BoxCollider2D>();

        if (_attackCollsion != null)
            _cam = transform.root.transform.Find("Virtual Camera").transform;
    }


    /*private void Start()
    {
        //_defaltYPos = transform.position.y;

        //_speed = 0;
        //Accelation = _maxSpeed;
        ////열차 길이 설정
        //for (int i = 1; i <= _trainLength; i++)
        //{
        //    GameObject _Line = Instantiate(_train);
        //    _Line.transform.SetParent(transform, false);
        //    _Line.transform.position = transform.position + new Vector3((i * -2f), 0);
        //}
        //열차 길이 설정

    }

    private void OnEnable()
    {
        _defaltYPos = transform.position.y;

        _speed = 0;

        for (int i = 1; i <= _trainLength; i++)
        {
            GameObject unit = Instantiate(_train, transform);
            _lineList.Add(unit);
            unit.transform.localPosition += new Vector3((i * -2f), 0);
        }
    }*/

    private void OnEnable()
    {
        _defaltYPos = transform.position.y;

        _speed = 0;
        //열차 길이 설정
        for (int i = 1; i <= _trainLength; i++)
        {
            GameObject _line = Instantiate(_train, transform);
            _lineList.Add(_line);
            _line.transform.position = transform.position + new Vector3((i * -2.25f), 0);
        }
        if (_attackCollsion != null)
            _attackCollsion.AttackEvent += HandleAttackEvent;

    }

    private void HandleAttackEvent()
    {
        CameraUtile.CameraShake(_cam.GetComponent<CinemachineVirtualCamera>(), Vector3.one * 2, 2, 2);
        Invoke(nameof(ReSetShakeValue), 0.2f);
    }
    private void ReSetShakeValue()
    {
        CameraUtile.CameraShake(_cam.GetComponent<CinemachineVirtualCamera>(), Vector3.zero, 0, 0);
    }
    private void OnDisable()
    {

        _rearground = false;
        _speed = 0;
        _accel = 0;

        StopCoroutine("AttackDealy");
        StopCoroutine("BackAway");

        for (int i = 0; i < _lineList.Count; i++)
        {
            Destroy(_lineList[i].gameObject);
        }
        if (_attackCollsion != null)
            _attackCollsion.AttackEvent -= HandleAttackEvent;
    }

    private void Update()
    {
        //현재 속도
        if (_Rigid.velocity.x < _AttackSpeed)
        {
            StartCoroutine(Lower());
        }
        else
        {
            _AttackCollision.SetActive(true);
        }

    }
    private void FixedUpdate()
    {
        if (!_rearground && !isMove)
        {
            _speed = 0.05f;
            _accel = Mathf.Lerp(_accel, _maxSpeed, _speed);
            //이동
            _Rigid.velocity = new Vector2(1, 0) * _accel;
        }
        else if (_rearground && !isMove)
        {

            time += 0.05f;

            _accel = _maxSpeed - time * _maxSpeed / _DealayTime / 3;
            //이동
            _Rigid.velocity = new Vector2(-1, 0) * _accel;
        }
        else if (isMove)
        {
            _Rigid.velocity = Vector2.zero;
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
        yield return new WaitForSeconds(0.2f);
        time = 0;
        _rearground = true;
        _hitBox.enabled = false;

        _accel = 0;

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


        _accel = 0;
        _speed = 0;
        _rearground = false;

    }
    IEnumerator Lower()
    {
        yield return new WaitForSeconds(0.02f);
        _AttackCollision.SetActive(false);
    }
}
