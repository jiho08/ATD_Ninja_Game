using DG.Tweening;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;
using Microsoft.Unity.VisualStudio.Editor;
using System;

public class WorldMapManager : MonoBehaviour
{
    GameObject currentStage;
    public GameObject train;
    int currentIndex;
    int targetIndex;
    public GameObject[] stages;
    public bool[] isOpenStages;
    public GameObject[] stageViews;
    private Dictionary<int, GameObject> objDic;

    IEnumerator coroutine;

    private void Awake()
    {
        objDic = new Dictionary<int, GameObject>();
    }
    void Start()
    {
        currentStage = stages[0];
        train.transform.position = currentStage.transform.position;
        currentIndex = 0;
        for (int i = 0; i < stageViews.Length; ++i)
        {
            objDic.Add(i, stageViews[i]);
            objDic[i].SetActive(false);
        }
        stageViews[0].SetActive(true);
    }

    private void Update()
    {
        stages[0].SetActive(isOpenStages[0]);
        stages[1].SetActive(isOpenStages[1]);
        stages[2].SetActive(isOpenStages[2]);
        stages[3].SetActive(isOpenStages[3]);
        stages[4].SetActive(isOpenStages[4]);
        stages[5].SetActive(isOpenStages[5]);
    }

   
    public void SetTargetStage(int value)
    {
        {
            Sequence moveStage = DOTween.Sequence();
            targetIndex = value;
            float startIndex = currentIndex;
            float moveDelay = 0;
            if (train.transform.position == stages[currentIndex].transform.position)
            {
                moveDelay = SetMoveDelay(startIndex, value);
            }

            if (currentIndex < value)
            {
                for (int i = currentIndex; i < targetIndex;)
                {
                    i++;
                    moveStage.Append(train.transform.DOMove(stages[i].transform.position,moveDelay));
                    currentStage = stages[i];
                }
            }
            else if (currentIndex > value)
            {
                for (int i = currentIndex; i > targetIndex;)
                {
                    i--;
                    moveStage.Append(train.transform.DOMove(stages[i].transform.position, moveDelay));
                }
            }
            coroutine = SetStageView(value, moveDelay * Mathf.Abs(targetIndex - startIndex));
            currentIndex = value;
            StartCoroutine(coroutine);

        }
    }

    private float SetMoveDelay(float startIndex, int value)
    {
        if (startIndex == 5 + 1)
        {
            return 0.25f;
        }
        else
        {
            return 1f / Mathf.Abs(startIndex - targetIndex);
        }
    }

    public void QuitBtn()
    {
        stageViews[0].SetActive(false);
        stageViews[1].SetActive(false);
        stageViews[2].SetActive(false);
        stageViews[3].SetActive(false);
        stageViews[4].SetActive(false);
        stageViews[5].SetActive(false);
        SceneManager.LoadScene(4);

    }
    private void SetStageView(int idx)
    {
        for (int i = 0; i < stageViews.Length; i++)
        {
            if (idx == i)
                objDic[i].SetActive(true);
            else
                objDic[i].SetActive(false);
        }
    }

    IEnumerator SetStageView(int idx, float delay)
    {
        if (coroutine != null)
        {
            coroutine = null;
        }
        yield return new WaitForSeconds(delay);
        SetStageView(idx);
        yield break;
    }
    public GameObject GetCurrentStage()
    {
        return currentStage;
    }
}
