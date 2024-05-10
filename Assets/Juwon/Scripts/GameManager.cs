using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public delegate void MinValue(float value);
    public event MinValue OnMinValue;
    
    [Header("---")]
    [SerializeField] private GetStageNumberSo stageNum;
    [SerializeField] BlackSceneFade blackScene;
    [SerializeField] toMainMenuSO toMainMenu;

    [SerializeField] private TextMeshProUGUI curTimerScore;

    private float _currentTime;
    private float _minTime;
    private bool _isTimeOver;

    private void Start()
    {
        AudioManager.Instance.PlayBgm(true, 1);

        _minTime = stageNum.timer;
    }

    private void Update()
    {
        if(_isTimeOver) return;
        
        _currentTime += Time.deltaTime;
    }

    private void LateUpdate()
    {
        curTimerScore.text = $"0{(int)_currentTime / 60} : {(int)_currentTime % 60}";
    }

    public void SetMaxTime()
    {
        //스테이지를 클리어 하면 발생하는 이벤트들 더 적기(최소 시간, 걸린시간)
        _isTimeOver = true;
        OnMinValue.Invoke(_currentTime);
    }


    public void BackBtn()
    {
        AudioManager.Instance.PlayBgm(true, 0);
        toMainMenu.DidEndGame = true;
        blackScene.ExitScene(2);
        //SceneManager.LoadScene(1);
    }

    public void WinGame(int stageNumber)
    {
        toMainMenu.DidWinGame = true;
        toMainMenu.whichStageEnded = stageNumber;
        stageNum.isOpenStage[Mathf.Clamp(stageNumber + 1, 0, 2)] = true;
        BackBtn();
    }
    
}
