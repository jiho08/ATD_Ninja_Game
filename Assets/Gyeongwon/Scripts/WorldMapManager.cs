using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMapManager : MonoBehaviour
{
    GameObject currentStage;
    GameObject targetStage;
    public GameObject train;
    Vector3 moveDir;
    public GameObject[] stages;
    //int startindex;
    //int endindex;
  

    private Coroutine currentRoutine;

    void Start()
    {
        currentStage = stages[0];
        train.transform.position = currentStage.transform.position;
        //startindex = 0;
    }


    public void SetTargetStage1()
    {
        targetStage = stages[0];
        currentRoutine = StartCoroutine(MoveRoutine());
        currentStage = targetStage;
        //startindex = 0;
    }
    public void SetTargetStage2()
    {
        targetStage = stages[1];
        currentRoutine = StartCoroutine(MoveRoutine());
        currentStage = targetStage;
        //startindex = 1;
    }
    public void SetTargetStage3()
    {
        //endindex = 3;
        //for (int i = startindex; i != endindex;)
        //{
        //    if (i < endindex)
        //    {
        //        i++;
        //    }
        //    else if (i > endindex)
        //    {
        //        i--;
        //    }
        //    targetStage = stages[i];
        //    currentRoutine = StartCoroutine(MoveRoutine());
        //    startindex = i;
        //}
        targetStage = stages[2];
        currentRoutine = StartCoroutine(MoveRoutine());
        currentStage = targetStage;
        //startindex = 2;
    }
    public void SetTargetStage4()
    {
        targetStage = stages[3];
        currentRoutine = StartCoroutine(MoveRoutine());
        currentStage = targetStage;
        //startindex = 3;
    }
    public void SetTargetStage5()
    {
        targetStage = stages[4];
        currentRoutine = StartCoroutine(MoveRoutine());
        currentStage = targetStage;
        //startindex = 4;
    }
    public void SetTargetStage6()
    {
        targetStage = stages[5];
        currentRoutine = StartCoroutine(MoveRoutine());
        currentStage = targetStage;
        //startindex = 5;
    }

    private IEnumerator MoveRoutine()
    {
        if (currentRoutine != null)
            StopCoroutine(currentRoutine);
        float percent = 0;
        float currentTime = 0;

        while (percent < 1)
        {
            yield return null;
            currentTime += Time.deltaTime;
            percent = currentTime / 5f;
            train.transform.position = Vector3.Lerp(train.transform.position, targetStage.transform.position, percent);
        }
    }
}
