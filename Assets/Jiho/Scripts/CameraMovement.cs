using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform _SettingPosition;
    [SerializeField] Transform _MainPosition;
    bool check = false;

    private void FixedUpdate()
    {
        if (check) // == check == ture
        {
            transform.position = Vector3.Slerp(gameObject.transform.position, _SettingPosition.transform.position, 0.05f);
        }
        if (!check) // == check == false
        {
            transform.position = Vector3.Slerp(gameObject.transform.position, _MainPosition.transform.position, 0.05f);
        }
    }
    public void ClickSetting()
    {
        check = true;
    }
    public void ClickMain()
    {
        check = false;
    }
}
