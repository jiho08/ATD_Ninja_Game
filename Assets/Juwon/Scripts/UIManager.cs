using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private SpawnManager spawnM;
    
    [SerializeField] private TextMeshProUGUI[] getSpawnEnemyNumTxts;

    private void Start()
    {
        spawnM.currentUnitNum.OnValueChanged += HandleChangeUnitSpawnCount;
    }
    
    //아군 최대 수 생성 표시
    private void HandleChangeUnitSpawnCount(int[] prev, int[] next)
    {
        getSpawnEnemyNumTxts[0].text = $"{next[0]} / {spawnM.GetDefaultCounts(0)}";
        getSpawnEnemyNumTxts[1].text = $"{next[1]} / {spawnM.GetDefaultCounts(1)}";
        getSpawnEnemyNumTxts[2].text = $"{next[2]} / {spawnM.GetDefaultCounts(2)}";
    }


}
