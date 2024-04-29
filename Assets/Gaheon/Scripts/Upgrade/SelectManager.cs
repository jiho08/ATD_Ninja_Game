using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class SelectManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI descText;
    [SerializeField] TextMeshProUGUI roleText;

    [SerializeField] UnitLevelUpSO ktxLevelSO;
    [SerializeField] UnitLevelUpSO mghLevelSO;
    [SerializeField] UnitLevelUpSO line1LevelSO;

    public UnitDataSO ktxSO;
    public UnitDataSO mghSO;
    public UnitDataSO line1SO;

    public UnitLevelUpSO selectedUnitLevel;
    public UnitDataSO selectedSO; //바에서도 사용 할 듯 

    [SerializeField] UnityEvent OnSelectChanged;

    public static SelectManager selectInstance;
    private void Awake()
    {
        if (selectInstance == null)
        {
            selectInstance = this;
        }
    }
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

