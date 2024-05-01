using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainButtonManager : MonoBehaviour
{
    CameraMovement _moveSetting;
    CameraMovement _moveMain;

    private void Awake()
    {
        _moveSetting = GameObject.Find("Main Camera").GetComponent<CameraMovement>();
        _moveMain = GameObject.Find("Main Camera").GetComponent<CameraMovement>();
    }

    public void GameStart()
    {
        SceneManager.LoadScene(5);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Setting()
    {
        _moveSetting.ClickSetting();
    }

    public void Back()
    {
        _moveMain.ClickMain();
    }
}
