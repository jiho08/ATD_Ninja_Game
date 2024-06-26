using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAdUnit : MonoBehaviour
{
    RaycastHit2D _rangeFinder;
    [SerializeField]
    private float _fireRange;
    private PoolManager poolM;

    [SerializeField]
    private float _shotColltime;

    private Animator _anim;

    bool _isFire = true;
    private void Awake()
    {
        poolM = GameObject.Find("Pool").GetComponent<PoolManager>();//풀 매니저 받아오기
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position + new Vector3(-1.25f, 0), Vector3.left * _fireRange, Color.green);
        _rangeFinder = Physics2D.Raycast(transform.position, Vector2.left, _fireRange, LayerMask.GetMask("Player"));


        if (_rangeFinder.collider != null && _rangeFinder.collider.gameObject.tag == "Player")
        {
            if (_isFire)
            {

                StartCoroutine(Colltime());

            }
        }
    }

    IEnumerator Colltime()
    {
        _isFire = false;

        GameObject _spawnedBullet = poolM.Get(1);

        _anim.SetTrigger("SetFire");

        _spawnedBullet.transform.rotation = Quaternion.Euler(0, 0, 90);
        _spawnedBullet.transform.position = transform.position;

        yield return new WaitForSeconds(_shotColltime);

        _isFire = true;
    }
}
