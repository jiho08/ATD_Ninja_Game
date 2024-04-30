using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class SelectManager : MonoBehaviour
{
    [Header("Info")]
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI descText;
    [SerializeField] TextMeshProUGUI roleText;


    [Header("Level SO")]
    [SerializeField] UnitLevelUpSO ktxLevelSO;
    [SerializeField] UnitLevelUpSO mghLevelSO;
    [SerializeField] UnitLevelUpSO line1LevelSO;

    [Header("기차 스프라이트")]
    [SerializeField] SpriteRenderer trainHead;
    [SerializeField] SpriteRenderer[] trainBody;
    public BoxCollider2D[] trainCollider;
    
    [Header("SO")]
    public UnitDataSO ktxSO;
    public UnitDataSO mghSO;
    public UnitDataSO line1SO;

    public UnitLevelUpSO selectedUnitLevel;
    public UnitDataSO selectedSO; //바에서도 사용 할 듯 

    [SerializeField] UnityEvent OnSelectChanged;

    void Start()
    {
        Selecting();
    }

    public void Selecting()
    {
        selectedSO.Hp = selectedUnitLevel.Hp[selectedSO.level - 1];
        selectedSO.Atk = selectedUnitLevel.Atk[selectedSO.level - 1];
        selectedSO.Speed = selectedUnitLevel.Speed[selectedSO.level - 1];
        
        nameText.text = selectedSO.TrainName;
        descText.text = selectedSO.TrainDesc;
        roleText.text = selectedSO.TrainRole;

        trainHead.sprite = selectedSO.TrainHead;
        trainBody[0].sprite = selectedSO.TrainBody;
        trainBody[1].sprite = selectedSO.TrainBody;

        trainCollider[0].size = trainHead.bounds.size;
        trainCollider[1].size = trainBody[0].bounds.size;
        trainCollider[2].size = trainBody[0].bounds.size;

        OnSelectChanged.Invoke();
    }
    public void KTX()
    {
        selectedSO = ktxSO;
        selectedUnitLevel = ktxLevelSO;
        Selecting();
    }
    public void MGH()
    {
        selectedSO = mghSO;
        selectedUnitLevel = mghLevelSO;
        Selecting();
    }
    public void Line1()
    {
        selectedSO = line1SO;
        selectedUnitLevel = line1LevelSO;
        Selecting();
    }

}

