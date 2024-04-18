using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public struct TrainStates
{
    public string Name;
    public int HP;
    public int Strength;
    public int Speed;
}
public class JsonReader : MonoBehaviour
{
    public static JsonReader jsonInstance;
    public TrainStates trainStat = new TrainStates();
    string path;
    private void Awake()
    {
        path = Application.persistentDataPath + "/";
        if(jsonInstance == null)
        {
            jsonInstance = this;
        }
        DontDestroyOnLoad(this.gameObject);
        trainStat.Name = "±Í¿ä¹Ì";
    }
    private void Start()
    {
        SaveData();
        LoadData();
        Debug.Log(trainStat.Name);
    }

    public void SaveData()
    {
        string data = JsonUtility.ToJson(trainStat);
        File.WriteAllText(path + "TrainStates", data);
    }

    void LoadData()
    {
        string data = File.ReadAllText(path + "TrainStates");
        trainStat = JsonUtility.FromJson<TrainStates>(data);
    }
}
