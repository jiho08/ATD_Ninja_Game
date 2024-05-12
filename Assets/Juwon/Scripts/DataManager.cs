using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    // ---싱글톤으로 선언--- //
    public static DataManager Instance;

    // --- 게임 데이터 파일이름 설정 ("원하는 이름(영문).json") --- //
    string _gameDataFileName = "GameData.json";
    private string _filePath;

    // --- 저장용 클래스 변수 --- //
    public Data data = new Data();
    
    [Header("#SO")]
    #region SO

    public GetStageNumberSo getStageNum;
    public UnitDataSO[] unitData;
    public OwningUnitSO owningUnit;
    
    #endregion

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if(Instance != null)
        {
            Destroy(Instance.gameObject);
        }
        
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        //_filePath = Application.dataPath + "/" + GameDataFileName;
        _filePath = Application.persistentDataPath + "/" + _gameDataFileName;
        
        if (!File.Exists(_filePath))
        {
            ChangeData();
        }
        LoadSo();
    }

    // 불러오기
    public void LoadGameData()
    {
        // 저장된 게임이 있다면
        if (File.Exists(_filePath))
        {
            // 저장된 파일 읽어오고 Json을 클래스 형식으로 전환해서 할당
            string fromJsonData = File.ReadAllText(_filePath);
            data = JsonUtility.FromJson<Data>(fromJsonData);
        }
    }
    
    // 저장하기
    public void SaveGameData()
    {
        // 클래스를 Json 형식으로 전환 (true : 가독성 좋게 작성)
        string toJsonData = JsonUtility.ToJson(data, true);
        
        //string filePath = Application.dataPath + "/" + GameDataFileName;
        string filePath = Application.persistentDataPath + "/" + _gameDataFileName;

        // 이미 저장된 파일이 있다면 덮어쓰고, 없다면 새로 만들어서 저장
        File.WriteAllText(filePath, toJsonData);
    }
    
    public void LoadSo()
    {
        Instance.LoadGameData();

        //GetStageNumberSo
        getStageNum.isOpenStage = Instance.data.isOpenStage;
        getStageNum.isTutorial = Instance.data.isTutorial;

        //UnitDataSO
        for (int i = 0; i < 3; i++)
        {
            unitData[i].level = Instance.data.level[i];
            unitData[i].length = Instance.data.length[i];
            unitData[i].Hp = Instance.data.hp[i];
            unitData[i].Atk = Instance.data.atk[i];
            unitData[i].Speed = Instance.data.speed[i];
        }
        
        //OwningUnitSO
        owningUnit.OwningKTX = Instance.data.owningKtx;
        owningUnit.OwningMGH = Instance.data.owningMgh;
        owningUnit.OwningLine1 = Instance.data.owningLine1;
        
        Instance.SaveGameData();
    }

    public void ChangeData()
    {
        //GetStageNumberSo
        Instance.data.isOpenStage = getStageNum.isOpenStage;
        Instance.data.isTutorial = getStageNum.isTutorial;

        //UnitDataSO
        for (int i = 0; i < 3; i++)
        {
            Instance.data.level[i] = unitData[i].level;
            Instance.data.length[i] = unitData[i].length;
            Instance.data.hp[i] = unitData[i].Hp;
            Instance.data.atk[i] = unitData[i].Atk;
            Instance.data.speed[i] = unitData[i].Speed;
        }
        
        //OwningUnitSO
        Instance.data.owningKtx = owningUnit.OwningKTX;
        Instance.data.owningMgh = owningUnit.OwningMGH;
        Instance.data.owningLine1 = owningUnit.OwningLine1;
        
        Instance.SaveGameData();

        LoadSo();
    }
}