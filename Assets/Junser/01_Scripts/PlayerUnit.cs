using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : MonoBehaviour
{
    //HP���� ����

    [SerializeField]
    private float _damage;
    public float _GetDamage { get { return _damage; } }


    [SerializeField]
    private float _AttackSpeed;
    private float Accelation;
    [SerializeField]
    private float _accel;


    public float _maxSpeed;

    //���� ����

    [SerializeField]
    private int _trainLength;

    //�̵� ���� ����


    [SerializeField]
    private GameObject _AttackCollision;
    private Rigidbody2D _Rigid;
    private Firsttrain _firstTrain;
    private HealthManager _playerHealth;
    //������Ʈ �޾ƿ;��ϴ°͵�

    public float _DealayTime;
    float _speed;
    //�ڷ�ƾ

    [SerializeField]
    private GameObject _train;

    private void Awake()
    {
        //������Ʈ �޴� �κ�
        _Rigid = GetComponent<Rigidbody2D>();
        _firstTrain = GetComponentInChildren<Firsttrain>();
        _playerHealth = GetComponent<HealthManager>();
    }

    private void Start()
    {


        _speed = 0;
        Accelation = _maxSpeed;
        //���� ���� ����
        for (int i = 1; i <= _trainLength; i++)
        {
            GameObject _Line = Instantiate(_train);
            _Line.transform.SetParent(transform, false);
            _Line.transform.position = transform.position + new Vector3((i * -2f), 0);
        }
    }

    private void Update()
    {
        //���� �ӵ�

        //�̵� �ӵ� ����
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
        //�̵�
        _Rigid.velocity = new Vector2(1, 0) * _accel;
    }

    public void TakeDamage()//�ǰ� �޼���
    {
        StartCoroutine("BackAway");

        _firstTrain.HitBehave();
    }

    public void Dealy()//���� ������
    {
        StartCoroutine(AttackDealy());
    }

    IEnumerator BackAway()//�ǰ� �ൿ �ڷ�ƾ
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

    IEnumerator AttackDealy()// ���� ������ �ڷ�ƾ
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
