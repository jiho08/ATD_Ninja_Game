using DG.Tweening;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class WorldMapManager : MonoBehaviour
{
    GameObject currentStage;
    public GameObject train;
    int currentIndex;
    int targetIndex;
    public GameObject[] stages;
    public bool[] isOpenStages;
    public GameObject StageViews;
    private Dictionary<int, GameObject> objDic;
    public UnityEvent<int> OnStageChanged;

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
        if (train.transform.position == stages[currentIndex].transform.position)
        {
            {
                Sequence moveStage = DOTween.Sequence();
                targetIndex = value;
                float startIdx = currentIndex;

                if (currentIndex < value)
                {
                    for (int i = currentIndex; i < targetIndex;)
                    {
                        i++;
                        moveStage.Append(train.transform.DOMove(stages[i].transform.position, 1 / Mathf.Abs(targetIndex - startIdx)));
                        currentStage = stages[i];
                    }
                }
                else if (currentIndex > value)
                {
                    for (int i = currentIndex; i > targetIndex;)
                    {
                        i--;
                        moveStage.Append(train.transform.DOMove(stages[i].transform.position, 1 / Mathf.Abs(targetIndex - startIdx)));
                    }
                }
                coroutine = SetStageView(value, 1);
                StartCoroutine(coroutine);
                currentIndex = value;
            }
        }
    }

    public void QuitBtn()
    {
        StageViews.SetActive(false);
        SceneManager.LoadScene(4);

    }

    IEnumerator SetStageView(int stageIdx,float delay)
    {
        yield return new WaitForSeconds(delay);
        OnStageChanged?.Invoke(stageIdx);
        yield break;
    }

    public int GetCurrentIdx()
    {
        return currentIndex;
    }
}
