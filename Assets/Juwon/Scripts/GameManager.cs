using TMPro;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [Header("#UI")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI curTimerScore;
    [SerializeField] private TextMeshProUGUI clearTimerScore;
    
    [Header("---")]
    [SerializeField] private GetStageNumberSo stageNum;
    
    private float _currentTime;
    private float _maxTime;
    private bool _isTimeOver;

    private void Start()
    {
        AudioManager.Instance.PlayBgm(true, 0);

        _maxTime = stageNum.timer;
    }

    private void Update()
    {
        if(_isTimeOver) return;
        
        _currentTime += Time.deltaTime;
    }

    private void LateUpdate()
    {
        //curTimerScore.text = $"{_currentTime / 60} : {_currentTime % 60}";
    }

    public void StageClear()
    {
        //스테이지를 클리어 하면 발생하는 이벤트들 더 적기(최소 시간, 걸린시간)
        _isTimeOver = true;

        if (_currentTime > _maxTime)
        {
            _maxTime = _currentTime;
            clearTimerScore.text = $"{_maxTime / 60} : {_maxTime % 60}";
            stageNum.timer = _maxTime;
        }
        
        gameOverPanel.SetActive(true);
        AudioManager.Instance.PlayBgm(false, 1);
        Time.timeScale = 0;
    }   
    
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        AudioManager.Instance.PlayBgm(false, 1);
        Time.timeScale = 0;
    }
}
