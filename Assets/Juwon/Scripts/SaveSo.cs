using UnityEngine;

public class SaveSo : MonoBehaviour
{
    public GetStageNumberSo getStageNum;
    public UnitDataSO[] unitData;
    public OwningUnitSO owningUnit;

    private void Start()
    {
        if(!DataManager.Instance.data.isFirstGame) return;
        
        //GetStageNumberSo
        DataManager.Instance.data.isOpenStage = getStageNum.isOpenStage;
        DataManager.Instance.data.isTutorial = getStageNum.isTutorial;

        //UnitDataSO
        for (int i = 0; i < 3; i++)
        {
            DataManager.Instance.data.level[i] = unitData[i].level;
            DataManager.Instance.data.length[i] = unitData[i].length;
            DataManager.Instance.data.hp[i] = unitData[i].Hp;
            DataManager.Instance.data.atk[i] = unitData[i].Atk;
            DataManager.Instance.data.speed[i] = unitData[i].Speed;
        }
        
        //OwningUnitSO
        DataManager.Instance.data.owningKtx = owningUnit.OwningKTX;
        DataManager.Instance.data.owningMgh = owningUnit.OwningMGH;
        DataManager.Instance.data.owningLine1 = owningUnit.OwningLine1;

        DataManager.Instance.data.isFirstGame = false;
        
        DataManager.Instance.SaveGameData();
    }

    public void LoadSo()
    {
        DataManager.Instance.LoadGameData();
        
        //GetStageNumberSo
        getStageNum.isOpenStage = DataManager.Instance.data.isOpenStage;
        getStageNum.isTutorial = DataManager.Instance.data.isTutorial;

        //UnitDataSO
        for (int i = 0; i < 3; i++)
        {
            unitData[i].level = DataManager.Instance.data.level[i];
            unitData[i].length = DataManager.Instance.data.length[i];
            unitData[i].Hp = DataManager.Instance.data.hp[i];
            unitData[i].Atk = DataManager.Instance.data.atk[i];
            unitData[i].Speed = DataManager.Instance.data.speed[i];
        }
        
        //OwningUnitSO
        owningUnit.OwningKTX = DataManager.Instance.data.owningKtx;
        owningUnit.OwningMGH = DataManager.Instance.data.owningMgh;
        owningUnit.OwningLine1 = DataManager.Instance.data.owningLine1;
        
        DataManager.Instance.SaveGameData();
    }
}