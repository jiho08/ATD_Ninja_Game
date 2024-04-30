using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBtnClick : MonoBehaviour
{
    [SerializeField] GetStageNumberSo getStageNumberSo;

    public void StartBtn(int value)
    {
        getStageNumberSo.stageNumber = value;
        SceneManager.LoadScene(2    );
    }
}
