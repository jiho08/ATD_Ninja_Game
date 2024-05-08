using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTrainRoad : MonoBehaviour
{
    public GameObject[] TrainRoad;
    public GameObject[] Stages;
    public GameObject RedDot;
    WorldMapManager worldMapManager;
    IEnumerator coroutin;

    private void Awake()
    {
        worldMapManager = GetComponent<WorldMapManager>();
    }

    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            TrainRoad[i].SetActive(false);
        }
    }

    public void ShowRoad(int value)
    {
       if (worldMapManager.GetCurrentIdx() < value)
       {
            for (int i= worldMapManager.GetCurrentIdx(); i< value; i++)
            {
                TrainRoad[i].SetActive(true);
            }
       }
        if (worldMapManager.GetCurrentIdx() > value)
        {
            for (int i= worldMapManager.GetCurrentIdx(); i > value;)
            {
                i--;
                TrainRoad[i].SetActive(true);
            }
        }
        coroutin = WaitDelay(1);
        StartCoroutine(coroutin);

    }

    IEnumerator WaitDelay(int delay)
    {
        yield return new WaitForSeconds(delay);
        for (int i = 0; i < 5; i++)
        {
            TrainRoad[i].SetActive(false);
        }
    }
}
