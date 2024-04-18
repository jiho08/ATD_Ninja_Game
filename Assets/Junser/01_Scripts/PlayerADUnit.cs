using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerADUnit : MonoBehaviour
{
    RaycastHit2D _rangeFinder;
    [SerializeField]
    private float _fireRange;
    [SerializeField]
    private GameObject _bullet;

    [SerializeField]
    private float _shotColltime;

    bool _isFire = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position + new Vector3(1.25f, 0), Vector3.right*_fireRange, Color.green);
        _rangeFinder = Physics2D.Raycast(transform.position, Vector2.right, _fireRange, LayerMask.GetMask("Enemy"));


        if(_rangeFinder.collider != null &&_rangeFinder.collider.gameObject.tag == "Enemy")
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

        GameObject _spawnedBullet = Instantiate(_bullet);

        _spawnedBullet.transform.rotation = Quaternion.Euler(0, 0, 90);
        _spawnedBullet.transform.position = transform.position;

        yield return new WaitForSecondsRealtime(_shotColltime);

        _isFire = true;
    }
}
