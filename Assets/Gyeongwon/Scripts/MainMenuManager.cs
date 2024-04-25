using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void ToWorldMap()
    {
        SceneManager.LoadScene("WorldMap");
    }
    public void ToStation()
    { 
        //SceneManager.LoadScene("???");
    }
    public void ToTitle()
    {
        //SceneManager.LoadScene("???");
    }
}
