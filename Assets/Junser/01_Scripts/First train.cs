using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firsttrain : MonoBehaviour
{
    private float _dealayTime;
    private float _defaltPos;
    private PlayerUnit _unit;
    void Start()
    {
        _unit = GetComponentInParent<PlayerUnit>();
        transform.position = new Vector3(transform.position.x, _unit.transform.position.y);
        _dealayTime = GetComponentInParent<PlayerUnit>()._DealayTime;
    }
    private void OnDisable()
    {
        transform.position = new Vector3(transform.position.x, _unit.transform.position.y);
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HitBehave()
    {
        StartCoroutine("HitBehaveCoroutine");
    }
    private IEnumerator HitBehaveCoroutine()
    {
        _defaltPos = _unit.transform.position.y;


        transform.rotation = Quaternion.Euler(0, 0, 35);
        transform.position = new Vector3(transform.position.x, _defaltPos + 0.53522833687f);


        yield return new WaitForSeconds(_dealayTime);

        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.position = new Vector3(transform.position.x, _defaltPos);

        _defaltPos = transform.position.y;

    }
}
