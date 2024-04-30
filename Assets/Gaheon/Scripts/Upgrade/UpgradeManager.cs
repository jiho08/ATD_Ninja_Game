using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ktxLevelText;
    [SerializeField] TextMeshProUGUI mghLevelText;
    [SerializeField] TextMeshProUGUI line1LevelText;

    private void Start()
    {
        ChangeLevelText();
    }

    public void Upgrade()
    {
        if (SelectManager.selectInstance.selectedSO.level < 5)
        {
            SelectManager.selectInstance.selectedSO.level++;
            SelectManager.selectInstance.Selecting();
            ChangeLevelText();
        }
    }

    void ChangeLevelText()
    {
        ktxLevelText.text = $"{SelectManager.selectInstance.ktxSO.level}/5";
        mghLevelText.text = $"{SelectManager.selectInstance.mghSO.level}/5";
        line1LevelText.text = $"{SelectManager.selectInstance.line1SO.level}/5";
    }
}
