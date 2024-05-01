using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    private static int resource = 0;
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
        resource = PlayerPrefs.GetInt("Resource",0);
    }

    public void SetRsc(int value)
    {
        resource += value;
        PlayerPrefs.SetInt("Resource", resource);
    }
    public int GetRsc()
    {
        return resource;
    }
    public void ResetRsc()
    {
        resource = 0;
        PlayerPrefs.SetInt("Resource", resource);
    }

}
