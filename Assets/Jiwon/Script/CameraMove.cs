using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Vector3 mousePositiion;
    private Vector3 wordPosition;

    [SerializeField] private float _minX;
    [SerializeField] private float _maxX;

    private Camera camera;
    private void Start()
    {
        camera = Camera.main;


    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            // x축 방향으로 1만큼 이동 후 제한 적용
            float newX = Mathf.Clamp(transform.position.x + 1, _minX, _maxX);

            // 새로운 x값을 이용해 카메라의 위치 업데이트
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        }


    }

    private void ScrenentoWorld()
    {
        mousePositiion = Input.mousePosition;

        wordPosition = Camera.main.ScreenToWorldPoint(mousePositiion + new Vector3(0, 0, 10));
    }


}
