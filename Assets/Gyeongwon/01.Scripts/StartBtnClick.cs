using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBtnClick : MonoBehaviour
{
    [SerializeField] GetStageNumberSo getStageNumberSo;
    [SerializeField] private WorldMapManager worldM;
    int _stageNum;

    private void Start()
    {
        worldM.OnChangeStage += ChangeNum;
    }

    public void StartBtn()
    {
        if(getStageNumberSo.isTutorial)
        {
            SceneManager.LoadScene(4);
            getStageNumberSo.isTutorial = false;
            return;
        }
        getStageNumberSo.stageNumber = _stageNum;
        SceneManager.LoadScene(3);
    }

    private void ChangeNum(int value)
    {
        _stageNum = value+1;
    }
}
