using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //HP���� ����
    private HealthManager health;
    [SerializeField]
    private float _AttackSpeed;
    public float Accelation;
    

    private float _defaltPos;
    float _speed;
    public float _maxSpeed;

    //�̵� ���� ����
    
    public float _damage;
    public float _GetDamage { get; set; }
    private ParticleSystem _particle;

    [SerializeField]
    private GameObject _AttackCollision;
    private Rigidbody2D _Rigid;
    private BoxCollider2D _hitBox;
    //������Ʈ �޾ƿ;��ϴ°͵�

    private bool _isDealay;
    [SerializeField]
    private float _DealayTime;
    //�ڷ�ƾ

    float time = 0;
    private bool _rearground;
    [SerializeField]
    private float _accel;


    private void Awake()
    {
        //������Ʈ �ޱ�
        _Rigid = GetComponent<Rigidbody2D>();
        _particle = GetComponentInChildren<ParticleSystem>();
        _hitBox = GetComponent<BoxCollider2D>();
        health = GetComponent<HealthManager>();
    }

    private void Start()
    {
        _defaltPos = transform.position.y;

        _speed = 0;
        Accelation = _maxSpeed;
    }

    /*private void OnEnable()
    {
        _GetDamage = health.Damage;
    }*/

    private void Update()
    {
        
        //���� ���� ����
        

        if (_Rigid.velocity.x < _AttackSpeed)
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
        if (!_rearground)
        {
            _speed = 0.05f;
            _accel = Mathf.Lerp(_accel, Accelation, _speed);
            //�̵�
            _Rigid.velocity = new Vector2(-1, 0) * _accel;
        }
        else
        {

            time += 0.05f;

            _accel = _maxSpeed - time * _maxSpeed / _DealayTime / 3;
            
            //�̵�
            _Rigid.velocity = new Vector2(1, 0) * _accel;
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

    public void TakeDamage()
    {
        if (this.gameObject.activeSelf)
        {
            StartCoroutine(BackAway());
            _particle.Play();
        }


    }
    public void Dealy()
    {
        if (gameObject.activeSelf)
            StartCoroutine(AttackDealy());
    }
    IEnumerator BackAway()
    {
        time = 0;
        _rearground = true;
        _hitBox.enabled = false;

        _accel = 0;


        _AttackCollision.gameObject.SetActive(false);

        transform.rotation = Quaternion.Euler(0, 0, -35);
        transform.position = new Vector3(transform.position.x, _defaltPos + 0.53522833687f);

        yield return new WaitForSeconds(_DealayTime);

        transform.rotation = Quaternion.Euler(0, 0, 0);

        transform.position = new Vector3(transform.position.x, _defaltPos);

        _accel = 0;

        _speed = 0;
        _hitBox.enabled = true;
        _rearground = false;
    }

    IEnumerator AttackDealy()
    {

        _rearground = true;

        _accel = 0;

        time = 0;


        yield return new WaitForSeconds(_DealayTime);

        _AttackCollision.gameObject.SetActive(true);

        Accelation = _maxSpeed;
        _accel = 0;
        _speed = 0;
        _rearground = false;

    }
}

