using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager instance = null;
    private static int resource = 0;

    private void Awake()
    {
    if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        if (resource < 0)
        {
            resource = 0;
        }
        resource = PlayerPrefs.GetInt("Resource",0);
    }

    public void SetRsc(int value)
    {
        if (resource - value >= 0)
        {
            resource += value;
            PlayerPrefs.SetInt("Resource", resource);
        }
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
