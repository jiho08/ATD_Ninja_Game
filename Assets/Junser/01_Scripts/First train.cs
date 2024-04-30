using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firsttrain : MonoBehaviour
{
    private float _dealayTime;
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
        yield return null;


        transform.rotation = Quaternion.Euler(0, 0, 35);
        transform.position = new Vector3(transform.position.x, transform.position.y+0.53522833687f);

        yield return new WaitForSecondsRealtime(_dealayTime);

        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.53522833687f);
    }
}
