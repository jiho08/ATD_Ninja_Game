using System;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    // ---싱글톤으로 선언--- //
    public static DataManager Instance;

    // --- 게임 데이터 파일이름 설정 ("원하는 이름(영문).json") --- //
    string GameDataFileName = "GameData.json";

    // --- 저장용 클래스 변수 --- //
    public Data data = new Data();

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // 불러오기
    public void LoadGameData()
    {
        string filePath = Application.dataPath + "/" + GameDataFileName;

        //string filePath = Application.persistentDataPath + "/" + GameDataFileName;

        // 저장된 게임이 있다면
        if (File.Exists(filePath))
        {
            // 저장된 파일 읽어오고 Json을 클래스 형식으로 전환해서 할당
            string fromJsonData = File.ReadAllText(filePath);
            data = JsonUtility.FromJson<Data>(fromJsonData);
            print("불러오기 완료");
        }
    }


    // 저장하기
    public void SaveGameData()
    {
        // 클래스를 Json 형식으로 전환 (true : 가독성 좋게 작성)
        string toJsonData = JsonUtility.ToJson(data, true);
        string filePath = Application.dataPath + "/" + GameDataFileName;
        //string filePath = Application.persistentDataPath + "/" + GameDataFileName;

        // 이미 저장된 파일이 있다면 덮어쓰고, 없다면 새로 만들어서 저장
        File.WriteAllText(filePath, toJsonData);

        // 올바르게 저장됐는지 확인 (자유롭게 변형)
    }
}