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
    [SerializeField]
    private float DefaltAcclation;

    private float _defaltPos;
    //�̵� ���� ����
    [SerializeField]
    private float _damage;
    public float _GetDamage { get; private set; }
    private ParticleSystem _particle;

    [SerializeField]
    private GameObject _AttackCollision;
    private Rigidbody2D _Rigid;
    //������Ʈ �޾ƿ;��ϴ°͵�

    private bool _isDealay;
    [SerializeField]
    private float _DealayTime;
    //�ڷ�ƾ


    private void Awake()
    {
        //������Ʈ �ޱ�
        _Rigid = GetComponent<Rigidbody2D>();
        _particle = GetComponentInChildren<ParticleSystem>();
        health = GetComponent<HealthManager>();
    }

    private void OnEnable()
    {
        _GetDamage = health.Damage;
    }

    private void Start()
    {
        _defaltPos = transform.position.y;
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
        if (this.gameObject.activeSelf)
        {
            StartCoroutine(BackAway());
            _particle.Play();
        }


    }
    public void Dealy()
    {
        if (gameObject != null)
            StartCoroutine(AttackDealy());
    }
    IEnumerator BackAway()
    {


        transform.rotation = Quaternion.Euler(0, 0, -35);
        transform.position = new Vector3(transform.position.x, _defaltPos + 0.53522833687f);


        Accelation = -DefaltAcclation*2;
        yield return new WaitForSeconds(_DealayTime);

        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.position = new Vector3(transform.position.x, _defaltPos);


        Accelation = DefaltAcclation;
    }

    IEnumerator AttackDealy()
    {

        Accelation = -DefaltAcclation * 2;


        yield return new WaitForSeconds(_DealayTime);
        Accelation = DefaltAcclation;


    }
}
