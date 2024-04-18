using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Vector3 mousePositiion;
    private Vector3 wordPosition;

    private Vector3 ScreenCenter;
   

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse2))
        {
            ScrenentoWorld();

            transform.position = wordPosition;
            
        }
        
        else
        {
            ScreenCenter = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2));
            
            transform.position = new Vector3(ScreenCenter.x,ScreenCenter.y,0);
        }


    }

    private void ScrenentoWorld()
    {
        mousePositiion = Input.mousePosition;

        wordPosition = Camera.main.ScreenToWorldPoint(mousePositiion + new Vector3(0, 0, 10));
    }


}
