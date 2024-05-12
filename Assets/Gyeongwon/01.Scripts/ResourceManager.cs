using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager instance;
    private static int _resource;

    public int Resource
    {
        get => _resource;

        set
        {
            _resource += value;
            
            if (_resource < 0) _resource = 0;
            
            PlayerPrefs.SetInt("Resource", _resource);
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        _resource = PlayerPrefs.GetInt("Resource",0);
    }

    /*public void SetRsc(int value)
    {
        if (_resource - value >= 0)
        {
            _resource += value;
            PlayerPrefs.SetInt("Resource", _resource);
        }
    }
    public int GetRsc()
    {
        return _resource;
    }*/
    public void ResetRsc()
    {
        _resource = 0;
        PlayerPrefs.SetInt("Resource", _resource);
    }

}
