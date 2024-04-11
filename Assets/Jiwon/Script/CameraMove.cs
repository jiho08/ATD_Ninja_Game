using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Camera mainCam;

    [SerializeField]
    private float cameraSpeed;

    private void Start()
    {
        mainCam = Camera.main;
        

    }

    private void Update()
    {
        Vector2 mounseXY = mainCam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetKey(KeyCode.C))
        {
            if (mounseXY.x < -5)
            {
                transform.position += Vector3.left * cameraSpeed * Time.deltaTime;
            }
            else if (mounseXY.x > 5)
            {
                transform.position += Vector3.right * cameraSpeed * Time.deltaTime;
            }
            else
            {
                transform.position += Vector3.zero;
            }
        }
        else
        {
            transform.position += Vector3.zero;
        }

    }

    
}
