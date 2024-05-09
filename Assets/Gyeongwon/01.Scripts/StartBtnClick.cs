using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBtnClick : MonoBehaviour
{
    [SerializeField] GetStageNumberSo getStageNumberSo;
    [SerializeField] private WorldMapManager worldM;
    [SerializeField] BlackSceneFade blackScene;
    int _stageNum;

    private void Start()
    {
        worldM.OnChangeStage += ChangeNum;
    }

    public void StartBtn()
    {
        AudioManager.Instance.PlaySfx(AudioManager.Sfx.Btn);

        if (getStageNumberSo.isTutorial)
        {
            getStageNumberSo.isTutorial = false;
            blackScene.ExitScene(3);
            return;
        }
        getStageNumberSo.stageNumber = _stageNum;
        blackScene.ExitScene(_stageNum + 2);
    }

    private void ChangeNum(int value)
    {
        _stageNum = value + 1;
    }
}
