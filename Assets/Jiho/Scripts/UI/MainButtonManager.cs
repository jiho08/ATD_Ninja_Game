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
        AudioManager.Instance.PlaySfx(AudioManager.Sfx.Btn);
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        DataManager.Instance.SaveGameData();
        AudioManager.Instance.PlaySfx(AudioManager.Sfx.Btn);
        Application.Quit();
    }

    public void Setting()
    {
        AudioManager.Instance.PlaySfx(AudioManager.Sfx.Btn);
        _moveCameraSetting.ClickSetting();
    }

    public void Back()
    {
        AudioManager.Instance.PlaySfx(AudioManager.Sfx.Btn);
        _moveCameraSetting.ClickMain();
    }
}
