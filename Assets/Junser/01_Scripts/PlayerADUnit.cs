using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerADUnit : MonoBehaviour
{
    [SerializeField]
    private float _fireRange;

    private Animator _anim;

    private PlayerUnit moveunit;

    [SerializeField]
    private float _shotColltime;

    [SerializeField] private Transform pos;
    [SerializeField] private Vector2 size;
    [SerializeField] private LayerMask enemy;
    [SerializeField] private Rigidbody2D rigid;

    [SerializeField]
    private GameObject bulletpre;



    bool _isFire = true;

    private void Awake()
    {
        _anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        //Collider2D[] hit = Physics2D.OverlapBoxAll(pos.position, size, 0, enemy);
        //foreach (Collider2D item in hit)
        //{
        //    if (item != null)
        //    {
        //        if (TryGetComponent<PlayerUnit>(out PlayerUnit move) && _isFire)
        //        {
        //            moveunit = move;
        //            move.isMove = true;
        //            StartCoroutine(Colltime());
        //        }
        //    }
        //    else if(moveunit != null)
        //    {
        //        moveunit.isMove = false;
        //    }
        //}
        if(_isFire) StartCoroutine(Colltime());
        

        ////레이캐스트
        //Debug.DrawRay(transform.position + new Vector3(1.25f, 0), Vector3.right*_fireRange, Color.green);
        //_rangeFinder = Physics2D.Raycast(transform.position, Vector2.right, _fireRange, LayerMask.GetMask("Enemy"));

        ////사격 알고리즘
        //if(_rangeFinder.collider != null &&_rangeFinder.collider.gameObject.tag == "Enemy")
        //{
        //    if (_isFire)
        //    {
        //        StartCoroutine(Colltime());
        //        Debug.Log("맞았어!");

        //    }
        //}
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(pos.position, size);
    }

    IEnumerator Colltime()//발사 코루틴
    {
        _isFire = false;
        _anim.SetTrigger("Fire");

        GameObject bullet = Instantiate(bulletpre, transform);
        bullet.transform.position = transform.position;

        yield return new WaitForSeconds(_shotColltime);

        _isFire = true;
    }
}
