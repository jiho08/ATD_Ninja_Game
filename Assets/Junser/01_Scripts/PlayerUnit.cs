using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : MonoBehaviour
{
    [SerializeField]
    private float _MaxHp = 5;
    private float _CurrentHpPoint;
    
    private void Awake()
    {
        _CurrentHpPoint = _MaxHp;
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag == "Enemy")
        {
            EnemyScript _enemy = other.gameObject.GetComponent<EnemyScript>();
            
            if(_enemy != null)
            {
                TakeDamage(_enemy._damage);
            }
        }
    }

    private void TakeDamage(float _GetDamage)
    {
        _CurrentHpPoint -= _GetDamage;

        Debug.Log("Damaged");

        if(_CurrentHpPoint <= 0)
        {
            //»ç¸Á
        }
    }


}
