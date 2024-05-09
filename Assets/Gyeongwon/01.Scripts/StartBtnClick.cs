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
            blackScene.ExitScene(4);
            //SceneManager.LoadScene(4);
            return;
        }
        getStageNumberSo.stageNumber = _stageNum;
        blackScene.ExitScene(3);
        //SceneManager.LoadScene(3);
    }

    private void ChangeNum(int value)
    {
        _stageNum = value + 1;
    }
}
