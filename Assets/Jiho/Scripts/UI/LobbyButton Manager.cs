using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyButton : MonoBehaviour
{
    public void LoadWorldMap()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadTitle()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadUpgrade()
    {
        SceneManager.LoadScene(3);
    }
}
