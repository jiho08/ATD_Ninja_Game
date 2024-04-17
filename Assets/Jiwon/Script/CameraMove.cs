using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Vector3 mousePositiion;
    private Vector3 wordPosition;

    private Camera camera;
    private void Start()
    {
        camera = Camera.main;
        

    }

    private void Update()
    {
        

        if (Input.GetKey(KeyCode.C))
        {
            ScrenentoWorld();
            transform.position = wordPosition;
        }
        else
        {
            
        }
    }

    private void ScrenentoWorld()
    {
        mousePositiion = Input.mousePosition;

        wordPosition = Camera.main.ScreenToWorldPoint(mousePositiion + new Vector3(0, 0, 10));
    }

    
}
