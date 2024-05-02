using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    [SerializeField] GameObject otehrBg;
    [SerializeField] float bgMoveSpeed;
    [SerializeField] float moveRange = 36;
    void FixedUpdate()
    {
        transform.position += Vector3.left * bgMoveSpeed * Time.deltaTime;
        if(transform.position.x < -moveRange)
        {
            transform.position = otehrBg.transform.position + Vector3.right * moveRange;
        }
    }
}
