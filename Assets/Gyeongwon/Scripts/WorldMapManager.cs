using DG.Tweening;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

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

    public void SetTargetStage1()
    {
        Sequence moveStage = DOTween.Sequence();
        targetIndex = 0;
        if (currentIndex > 0)
        {
            for (int i = currentIndex; i > targetIndex;)
            {
                i--;
                moveStage.Append(train.transform.DOMove(stages[i].transform.position, 1));
            }
        }
        coroutine = SetStageView(0, Mathf.Abs(currentIndex - targetIndex));
        currentIndex = 0;
        StartCoroutine(coroutine);
    }

    public void SetTargetStage2()
    {
        Sequence moveStage = DOTween.Sequence();
        targetIndex = 1;
        if (currentIndex < 1)
        {
            for (int i = currentIndex; i < 1;)
            {
                i++;
                moveStage.Append(train.transform.DOMove(stages[i].transform.position, 1));
            }
        }
        else if (currentIndex > 1)
        {
            for (int i = currentIndex; i > targetIndex;)
            {
                i--;
                moveStage.Append(train.transform.DOMove(stages[i].transform.position, 1));
            }
        }
        coroutine = SetStageView(1, Mathf.Abs(currentIndex - targetIndex));
        currentIndex = 1;
        StartCoroutine(coroutine);
    }

    public void SetTargetStage3()
    {
        Sequence moveStage = DOTween.Sequence();
        targetIndex = 2;
        if (currentIndex < 2)
        {
            for (int i = currentIndex; i < 2;)
            {
                i++;
                moveStage.Append(train.transform.DOMove(stages[i].transform.position, 1));
            }
        }
        else if (currentIndex > 2)
        {
            for (int i = currentIndex; i > targetIndex;)
            {
                i--;
                moveStage.Append(train.transform.DOMove(stages[i].transform.position, 1));
            }
        }
        coroutine = SetStageView(2, Mathf.Abs(currentIndex - targetIndex));
        currentIndex = 2;
        StartCoroutine(coroutine);
    }

    public void SetTargetStage4()
    {
        Sequence moveStage = DOTween.Sequence();
        targetIndex = 3;
        if (currentIndex < 3)
        {
            for (int i = currentIndex; i < 3;)
            {
                i++;
                moveStage.Append(train.transform.DOMove(stages[i].transform.position, 1));
            }
        }
        else if (currentIndex > 3)
        {
            for (int i = currentIndex; i > targetIndex;)
            {
                i--;
                moveStage.Append(train.transform.DOMove(stages[i].transform.position, 1));
            }
        }
        coroutine = SetStageView(3, Mathf.Abs(currentIndex - targetIndex));
        currentIndex = 3;
        StartCoroutine(coroutine);
    }

    public void SetTargetStage5()
    {
        Sequence moveStage = DOTween.Sequence();
        targetIndex = 4;
        if (currentIndex < 4)
        {
            for (int i = currentIndex; i < 4;)
            {
                i++;
                moveStage.Append(train.transform.DOMove(stages[i].transform.position, 1));
            }
        }
        else if (currentIndex > 4)
        {
            for (int i = currentIndex; i > targetIndex;)
            {
                // 6 > 4 보다 커서
                i--;
                moveStage.Append(train.transform.DOMove(stages[i].transform.position, 1));
            }
        }
        coroutine = SetStageView(4, Mathf.Abs(currentIndex - targetIndex));
        currentIndex = 4;
        StartCoroutine(coroutine);
    }

    public void SetTargetStage6()
    {
        Sequence moveStage = DOTween.Sequence();
        targetIndex = 5;
        if (currentIndex < 5)
        {
            for (int i = currentIndex; i < 5;)
            {
                i++;
                moveStage.Append(train.transform.DOMove(stages[i].transform.position, 1));
            }
        }
        else if (currentIndex > 5)
        {
            for (int i = currentIndex; i > targetIndex;)
            {
                i--;
                moveStage.Append(train.transform.DOMove(stages[i].transform.position, 1));
            }
        }
        coroutine = SetStageView(5, Mathf.Abs(currentIndex - targetIndex));
        currentIndex = 5;
        StartCoroutine(coroutine);
    }

    public void QuitBtn()
    {
        stageViews[0].SetActive(false);
        stageViews[1].SetActive(false);
        stageViews[2].SetActive(false);
        stageViews[3].SetActive(false);
        stageViews[4].SetActive(false);
        stageViews[5].SetActive(false);
        SceneManager.LoadScene("MainMenu");

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
}
