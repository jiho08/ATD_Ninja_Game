using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerADUnit : MonoBehaviour
{
    RaycastHit2D _rangeFinder;
    [SerializeField]
    private float _fireRange;

    private PoolManager poolM;

    private Animator _anim;

    [SerializeField]
    private float _shotColltime;

    bool _isFire = true;

    private void Awake()
    {
        _anim = GetComponentInChildren<Animator>();
        poolM = GameObject.Find("Pool").GetComponent<PoolManager>();//Ǯ �Ŵ��� �޾ƿ���
    }

    void Update()
    {
        //����ĳ��Ʈ
        Debug.DrawRay(transform.position + new Vector3(1.25f, 0), Vector3.right*_fireRange, Color.green);
        _rangeFinder = Physics2D.Raycast(transform.position, Vector2.right, _fireRange, LayerMask.GetMask("Enemy"));

        //��� �˰���
        if(_rangeFinder.collider != null &&_rangeFinder.collider.gameObject.tag == "Enemy")
        {
            if (_isFire)
            {
                StartCoroutine(Colltime());
                
            }
        }
    }

    IEnumerator Colltime()//�߻� �ڷ�ƾ
    {
        _isFire = false;
        _anim.SetTrigger("shoot end");

        GameObject _spawnedBullet = poolM.Get(0);

        _spawnedBullet.transform.SetParent(this.transform, true);
        _spawnedBullet.transform.rotation = Quaternion.Euler(0, 0, 90);
        _spawnedBullet.transform.position = transform.position;

        yield return new WaitForSeconds(_shotColltime);


        _isFire = true;
    }
}
