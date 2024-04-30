using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] SelectManager selectManager;

    [SerializeField] TextMeshProUGUI ktxLevelText;
    [SerializeField] TextMeshProUGUI mghLevelText;
    [SerializeField] TextMeshProUGUI line1LevelText;

    private void Start()
    {
        ChangeLevelText();
    }

    public void Upgrade()
    {
        if (selectManager.selectedSO.level < 5)
        {
            selectManager.selectedSO.level++;
            selectManager.Selecting();
            ChangeLevelText();
        }
    }

    void ChangeLevelText()
    {
        ktxLevelText.text = $"{selectManager.ktxSO.level}/5";
        mghLevelText.text = $"{selectManager.mghSO.level}/5";
        line1LevelText.text = $"{selectManager.line1SO.level}/5";
    }
}
