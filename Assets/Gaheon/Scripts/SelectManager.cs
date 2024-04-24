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

    [SerializeField] UnitDataSO ktxSO;
    [SerializeField] UnitDataSO mghSO;
    [SerializeField] UnitDataSO line1SO;

    public UnitDataSO selectedSO; //바에서도 사용 할 듯 

    [SerializeField] UnityEvent OnSelectChanged;

    public static SelectManager selectInstance;
    private void Awake()
    {
        if(selectInstance == null)
        {
            selectInstance = this;
        }
    }
    void Start()
    {
        Selecting();
    }

    void Selecting()
    {
        nameText.text = selectedSO.TrainName;
        descText.text = selectedSO.TrainDesc;
        roleText.text = selectedSO.TrainRole;

        OnSelectChanged.Invoke();
    }
    public void KTX()
    {
        selectedSO = ktxSO;
        Selecting();
    }
    public void MGH()
    {
        selectedSO = mghSO;
        Selecting();
    }
    public void Line1()
    {
        selectedSO = line1SO;
        Selecting();
    }

}

