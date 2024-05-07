using TMPro;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public delegate void MinValue(float value);
    public event MinValue OnMinValue;
    
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

    public void SetMaxTime()
    {
        //스테이지를 클리어 하면 발생하는 이벤트들 더 적기(최소 시간, 걸린시간)
        _isTimeOver = true;

        if (_currentTime > _maxTime)
        {
            _maxTime = _currentTime;
            stageNum.timer = _maxTime;
            OnMinValue.Invoke(_maxTime);
        }
    }
    
}
