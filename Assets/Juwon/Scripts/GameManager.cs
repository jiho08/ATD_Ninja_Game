using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;

    private void Start()
    {
        AudioManager.Instance.PlayBgm(true);
    }

    public void StageClear()
    {
        //스테이지를 클리어 하면 발생하는 이벤트들 더 적기(최소 시간, 걸린시간)
        gameOverPanel.SetActive(true);
        AudioManager.Instance.PlayBgm(false);
        Time.timeScale = 0;
    }   
    
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        AudioManager.Instance.PlayBgm(false);
        Time.timeScale = 0;
    }
}
