using DG.Tweening;
using UnityEngine;

public class WorldMapManager : MonoBehaviour
{
    GameObject currentStage;
    GameObject targetStage;
    public GameObject train;
    public GameObject[] stages;
    [SerializeField] public bool open1 = false;
    [SerializeField] public bool open2 = false;
    [SerializeField] public bool open3 = false;
    [SerializeField] public bool open4 = false;
    [SerializeField] public bool open5 = false;
    [SerializeField] public bool open6 = false;
    public GameObject Stage1;
    public GameObject Stage2;
    public GameObject Stage3;
    public GameObject Stage4;
    public GameObject Stage5;
    public GameObject Stage6;
    int currentIndex;
    int targetIndex;

    //private Coroutine currentRoutine;

    void Start()
    {
        currentStage = stages[0];
        train.transform.position = currentStage.transform.position;
        currentIndex = 0;
        Stage1.SetActive(false);
        Stage2.SetActive(false);
        Stage3.SetActive(false);
        Stage4.SetActive(false);
        Stage5.SetActive(false);
        Stage6.SetActive(false);
        
    }

    private void Update()
    {
        
        stages[0].SetActive(open1);
        stages[1].SetActive(open2);
        stages[2].SetActive(open3);
        stages[3].SetActive(open4);
        stages[4].SetActive(open5);
        stages[5].SetActive(open6);
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
        Invoke("SetStageView1", Mathf.Abs(currentIndex - targetIndex));
        currentIndex = 0;
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
        Invoke("SetStageView2", Mathf.Abs(currentIndex - targetIndex));
        currentIndex = 1;
    }

    public void SetTargetStage3()
    {
        Sequence moveStage = DOTween.Sequence();
        targetIndex = 2;
        if (currentIndex < 2)
        {
            for (int i = currentIndex; i<2; )
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
        Invoke("SetStageView3", Mathf.Abs(currentIndex - targetIndex));
        currentIndex = 2;
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
        Invoke("SetStageView4", Mathf.Abs(currentIndex - targetIndex));
        currentIndex = 3;
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
                Debug.Log(train.transform.position);
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
        Invoke("SetStageView5", Mathf.Abs(currentIndex - targetIndex));
        currentIndex = 4;
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
        Invoke("SetStageView6", Mathf.Abs(currentIndex-targetIndex));
        currentIndex = 5;
    }



    private void SetStageView6()
    {
        Stage1.SetActive(false);
        Stage2.SetActive(false);
        Stage3.SetActive(false);
        Stage4.SetActive(false);
        Stage5.SetActive(false);
        Stage6.SetActive(true);
    }
    private void SetStageView5()
    {
        Stage1.SetActive(false);
        Stage2.SetActive(false);
        Stage3.SetActive(false);
        Stage4.SetActive(false);
        Stage5.SetActive(true);
        Stage6.SetActive(false);
    }
    private void SetStageView4()
    {
        Stage1.SetActive(false);
        Stage2.SetActive(false);
        Stage3.SetActive(false);
        Stage4.SetActive(true);
        Stage5.SetActive(false);
        Stage6.SetActive(false);
    }
    private void SetStageView3()
    {
        Stage1.SetActive(false);
        Stage2.SetActive(false);
        Stage3.SetActive(true);
        Stage4.SetActive(false);
        Stage5.SetActive(false);
        Stage6.SetActive(false);
    }
    private void SetStageView2()
    {
        Stage1.SetActive(false);
        Stage2.SetActive(true);
        Stage3.SetActive(false);
        Stage4.SetActive(false);
        Stage5.SetActive(false);
        Stage6.SetActive(false);
    }
    private void SetStageView1()
    {
        Stage1.SetActive(true);
        Stage2.SetActive(false);
        Stage3.SetActive(false);
        Stage4.SetActive(false);
        Stage5.SetActive(false);
        Stage6.SetActive(false);
    }


}
