using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameManager gameM;
    [SerializeField] private SpawnManager spawnM;
    
    [SerializeField] private TextMeshProUGUI[] getSpawnEnemyNumTxts;
    
    [SerializeField] private GameObject gameclearPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI curTimerScore;
    [SerializeField] private TextMeshProUGUI clearTimerScore;

    private void Start()
    {
        spawnM.currentUnitNum.OnValueChanged += HandleChangeUnitSpawnCount;
        gameM.OnMinValue += MaxTimeUI;
    }
    
    //아군 최대 수 생성 표시
    private void HandleChangeUnitSpawnCount(int prev, int next)
    {
        getSpawnEnemyNumTxts[0].text = $"({spawnM.GetSpawnCounts[0]} / {spawnM.GetDefaultCounts(0)})";
        getSpawnEnemyNumTxts[1].text = $"({spawnM.GetSpawnCounts[1]} / {spawnM.GetDefaultCounts(1)})";
        getSpawnEnemyNumTxts[2].text = $"({spawnM.GetSpawnCounts[2]} / {spawnM.GetDefaultCounts(2)})";
    }
    
    public void StageClear()
    {
        gameOverPanel.SetActive(true);
        AudioManager.Instance.PlaySfx(AudioManager.Sfx.Victory);
        AudioManager.Instance.PlayBgm(false, 1);
        Time.timeScale = 0;
    }   
    
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        AudioManager.Instance.PlaySfx(AudioManager.Sfx.Defeat);
        AudioManager.Instance.PlayBgm(false, 1);
        Time.timeScale = 0;
    }

    public void MaxTimeUI(float value)
    {
        clearTimerScore.text = $"{value / 60} : {value % 60}";
    }
}
