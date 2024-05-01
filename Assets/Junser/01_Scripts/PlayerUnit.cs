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
    public float Accelation;


    public float DefaltAcclation;

    //���� ����

    [SerializeField]
    private int _trainLength;

    //�̵� ���� ����


    [SerializeField]
    private GameObject _AttackCollision;
    private Rigidbody2D _Rigid;
    private Firsttrain _firstTrain;
    //������Ʈ �޾ƿ;��ϴ°͵�

    public float _DealayTime;
    //�ڷ�ƾ

    [SerializeField]
    private GameObject _train;

    private void Awake()
    {
        //������Ʈ �޴� �κ�
        _Rigid = GetComponent<Rigidbody2D>();
        _firstTrain = GetComponentInChildren<Firsttrain>();
    }

    private void Start()
    {
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
        float _speed = _Rigid.velocity.x;

        //�̵� �ӵ� ����
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
        //�̵�
        _Rigid.velocity = new Vector2(1, 0) * Accelation;
    }

    public void TakeDamage()//�ǰ� �޼���
    {
        StartCoroutine(BackAway());
        
        StartCoroutine(_firstTrain.HitBehave());
    }

    public void Dealy()//���� ������
    {
        StartCoroutine(AttackDealy());
    }

    IEnumerator BackAway()//�ǰ� �ൿ �ڷ�ƾ
    {

        yield return new WaitForSecondsRealtime(0.1f);

        Accelation = -DefaltAcclation*2;

        _AttackCollision.gameObject.SetActive(false);


        yield return new WaitForSecondsRealtime(_DealayTime);

        Accelation = DefaltAcclation;

    }

    IEnumerator AttackDealy()// ���� ������ �ڷ�ƾ
    {
        yield return new WaitForSecondsRealtime(0.1f);


        Accelation = -DefaltAcclation;

        yield return new WaitForSecondsRealtime(_DealayTime);

        _AttackCollision.gameObject.SetActive(true);

        Accelation = DefaltAcclation;

        
    }
}
