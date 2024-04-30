using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : MonoBehaviour
{
    //HP관련 변수

    [SerializeField]
    private float _AttackSpeed;
    public float Accelation;
    [SerializeField]
    private float DefaltAcclation;

    //열차 길이

    [SerializeField]
    private int _trainLength;

    //이동 관련 변수


    [SerializeField]
    private GameObject _AttackCollision;
    private Rigidbody2D _Rigid;
    private Firsttrain _firstTrain;
    //컴포넌트 받아와야하는것들

    public float _DealayTime;
    //코루틴

    [SerializeField]
    private GameObject _train;

    private void Awake()
    {
        //컴포넌트 받는 부분
        _Rigid = GetComponent<Rigidbody2D>();
        _firstTrain = GetComponentInChildren<Firsttrain>();
    }

    private void Start()
    {
        //열차 길이 설정
        for (int i = 1; i <= _trainLength; i++)
        {
            GameObject _Line = Instantiate(_train);
            _Line.transform.SetParent(transform, false);
            _Line.transform.position = transform.position + new Vector3((i * -2.5f), 0);
        }
    }

    private void Update()
    {
        //현재 속도
        float _speed = _Rigid.velocity.x;

        //이동 속도 제한
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
        //이동
        _Rigid.velocity = new Vector2(1, 0) * Accelation;
    }

    public void TakeDamage()//피격 메서드
    {
        StartCoroutine(BackAway());
        StartCoroutine(_firstTrain.HitBehave());
    }

    public void Dealy()//공격 딜레이
    {
        StartCoroutine(AttackDealy());
    }

    IEnumerator BackAway()//피격 행동 코루틴
    {

        yield return new WaitForSecondsRealtime(0.1f);

        Accelation = -DefaltAcclation*2;

        yield return new WaitForSecondsRealtime(_DealayTime);

        Accelation = DefaltAcclation;

    }

    IEnumerator AttackDealy()// 공격 딜레이 코루틴
    {
        yield return new WaitForSecondsRealtime(0.1f);


        Accelation = -DefaltAcclation;

        yield return new WaitForSecondsRealtime(_DealayTime);


        Accelation = DefaltAcclation;
    }
}
