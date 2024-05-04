using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firsttrain : MonoBehaviour
{
    private float _dealayTime;
    private float _defaltPos;
    void Start()
    {
        _dealayTime = GetComponentInParent<PlayerUnit>()._DealayTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator HitBehave()
    {
        _defaltPos = transform.position.y;
        yield return null;


        transform.rotation = Quaternion.Euler(0, 0, 35);
        transform.position = new Vector3(transform.position.x, _defaltPos + 0.53522833687f);


        yield return new WaitForSecondsRealtime(_dealayTime);

        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.position = new Vector3(transform.position.x, _defaltPos);

        _defaltPos = transform.position.y;

    }
}
