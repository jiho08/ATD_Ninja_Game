using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyButton : MonoBehaviour
{
    public void LoadWorldMap()
    {
        AudioManager.Instance.PlaySfx(AudioManager.Sfx.Btn);
        SceneManager.LoadScene(0);
    }

    public void LoadTitle()
    {
        AudioManager.Instance.PlaySfx(AudioManager.Sfx.Btn);
        SceneManager.LoadScene(2);
    }

    public void LoadUpgrade()
    {
        AudioManager.Instance.PlaySfx(AudioManager.Sfx.Btn);
        SceneManager.LoadScene(3);
    }
}
