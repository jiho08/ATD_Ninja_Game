using DG.Tweening;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System;

public class WorldMapManager : MonoBehaviour
{
    GameObject currentStage;
    public GameObject Reddot;
    private int currentIndex;
    int targetIndex;
    public GameObject[] stages;
    public bool[] isOpenStages;
    public GameObject StageViews;
    private Dictionary<int, GameObject> objDic;
    public UnityEvent<int> OnStageChanged;
    [SerializeField] private GetStageNumberSo getStageNumber;
    public delegate void ChangeStageNum(int value);
    public ChangeStageNum OnChangeStage;
    public event Action OnMoving;
    public event Action NoMoving;

    IEnumerator coroutine;

    private void Awake()
    {
        objDic = new Dictionary<int, GameObject>();
    }
    void Start()
    {
        currentStage = stages[0];
        Reddot.transform.position = currentStage.transform.position;
        currentIndex = 0;

        for (int i = 0; i < getStageNumber.isOpenStage.Length; i++)
        {
            isOpenStages[i] = getStageNumber.isOpenStage[i];
        }

        stages[0].SetActive(isOpenStages[0]);
        stages[1].SetActive(isOpenStages[1]);
        stages[2].SetActive(isOpenStages[2]);
        
        getStageNumber.stageNumber = 0;
    }

   
    public void SetTargetStage(int value)
    {
        getStageNumber.stageNumber = value;
        if (Reddot.transform.position == stages[currentIndex].transform.position)
        {
            OnMoving?.Invoke();
            AudioManager.Instance.PlaySfx(AudioManager.Sfx.Btn);
            OnChangeStage.Invoke(value);
            {
                Sequence moveStage = DOTween.Sequence();
                targetIndex = value;
                float startIdx = currentIndex;

                if (currentIndex < value)
                {
                    for (int i = currentIndex; i < targetIndex;)
                    {
                        i++;
                        moveStage.Append(Reddot.transform.DOMove(stages[i].transform.position, 1 / Mathf.Abs(targetIndex - startIdx)));
                        currentStage = stages[i];
                    }
                }
                else if (currentIndex > value)
                {
                    for (int i = currentIndex; i > targetIndex;)
                    {
                        i--;
                        moveStage.Append(Reddot.transform.DOMove(stages[i].transform.position, 1 / Mathf.Abs(targetIndex - startIdx)));
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
        NoMoving?.Invoke();
        yield break;
    }

    public int GetCurrentIdx()
    {
        return currentIndex;
    }
}
