using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    private static int oddments = 0;
    public static ResourceManager instance = null;
    private void Awake()
    {
    if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        oddments = PlayerPrefs.GetInt("Oddments",0);
    }

    public void SetRsc(int value)
    {
        oddments += value;
        PlayerPrefs.SetInt("Oddments", oddments);
    }
    public int GetRsc()
    {
        return oddments;
    }
    public void ResetRsc()
    {
        oddments = 0;
        PlayerPrefs.SetInt("Oddments", oddments);
    }

}
