using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] private SpawnManager spawnM;
    [SerializeField] private GameObject paner;
    [SerializeField] private GameObject butten;
    [SerializeField] private Text text;
    [SerializeField] private GameObject cam;
    [SerializeField] private Transform enemyPos;
    [SerializeField] private Transform playerPod;

    [SerializeField] private string[] tuto;
    [SerializeField] private float[] tutoNum;

    private int count;

    private void Awake()
    {
        
    }
    private void Start()
    {
        spawnM.currentUnitNum.OnValueChanged += Tutorial02Start;
        count = 0;
        Off();
        
        StartCoroutine(Tutorial01());

    }

    private void Update()
    {

    }

    private void On()
    {
        Time.timeScale = 0;
        paner.SetActive(true);
        text.gameObject.SetActive(true);
    }

    private void Off()
    {
        text.text = " ";
        Time.timeScale = 1;
        paner.SetActive(false);
        butten.SetActive(false);
        text.gameObject.SetActive(false);
    }

    private void ClickBtn()
    {
        switch (count)
        {
            case 1:
                StartCoroutine(Tutorial02());
                break;
            case 2:
                StartCoroutine(Tutorial03());
                break;
            case 3:
                StartCoroutine(Tutorial04());
                break;
            case 4:
                StartCoroutine(Tutorial05());
                break;
            //case 5:
            //    StartCoroutine(Tutorial06());
            //    break;
        }
    }


    public void OnClickBtn()
    {
        Off();
        count++;
        ClickBtn();
    }
    private void Tutori()
    {
        Sequence txt = DOTween.Sequence();
        txt.SetUpdate(true);
        txt.Append(text.DOText(tuto[count], tutoNum[count]).SetEase(Ease.Unset));
    }

    private void Tutorial02Start(int prev, int next)
    {
        StartCoroutine(Tutorial06());
    }

    IEnumerator Tutorial01()
    {
        Debug.Log("tlatlago");
        cam.transform.position = Vector3.Lerp(cam.transform.position, new Vector3(enemyPos.transform.position.x, cam.transform.position.y, cam.transform.position.z), 1f);
        yield return new WaitForSecondsRealtime(2);
        Debug.Log(1);
        On();
        Tutori();
        yield return new WaitForSecondsRealtime(tutoNum[count] + 0.5f);
        butten.SetActive(true);

    }
    IEnumerator Tutorial02() 
    {
        yield return new WaitForSecondsRealtime(1f + 0.5f);
        Debug.Log(2);
        On();
        Tutori();
        yield return new WaitForSecondsRealtime(tutoNum[count] + 0.5f);
        butten.SetActive(true);

    }
    IEnumerator Tutorial03()
    {
        yield return new WaitForSecondsRealtime(3);
        Debug.Log(3);
        On();
        Tutori();
        yield return new WaitForSecondsRealtime(tutoNum[count] + 0.5f);
        butten.SetActive(true);
        
    }
    IEnumerator Tutorial04()
    {
        Debug.Log(4);
        On();
        Tutori();
        yield return new WaitForSecondsRealtime(tutoNum[count] + 0.5f);
        butten.SetActive(true);

    }
    IEnumerator Tutorial05()
    {
        Debug.Log(5);
        On();
        Tutori();
        yield return new WaitForSecondsRealtime(tutoNum[count] + 0.5f);
        butten.SetActive(true);

    }
    IEnumerator Tutorial06()
    {
        Debug.Log(6);
        On();
        Tutori();
        yield return new WaitForSecondsRealtime(tutoNum[count] + 0.5f);
        butten.SetActive(true);

    }

}
