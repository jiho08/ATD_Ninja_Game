using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainButtonManager : MonoBehaviour
{
    CameraMovement _moveCameraSetting;


    private void Awake()
    {
        _moveCameraSetting = Camera.main.GetComponent<CameraMovement>();
    }

    public void GameStart()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Setting()
    {
        _moveCameraSetting.ClickSetting();
    }

    public void Back()
    {
        _moveCameraSetting.ClickMain();
    }
}
