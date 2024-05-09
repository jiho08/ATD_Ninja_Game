using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] private SpawnManager spawnM;
    [SerializeField] private GameObject paner;
    [SerializeField] private GameObject butten;
    [SerializeField] private Text text;
    [SerializeField] private GameObject cam;
    [SerializeField] private Transform enemyPos;
    [SerializeField] private Transform playerPod;

    [SerializeField] private UIInputManager[] uiInputM;
    private CamMove camMove;
    

    [SerializeField] private string[] tuto;
    [SerializeField] private float[] tutoNum;

    [SerializeField] BlackSceneFade blackScene;
    private int count;

    private void Awake()
    {
        camMove = GetComponent<CamMove>();
    }

    private void Start()
    {
        count = 0;
        Off();
        
        StartCoroutine(Tutorial01());

        uiInputM[0].OnUnitNumChange += Tutorial02Start;
        uiInputM[1].OnUnitNumChange += Tutorial02Start;
        uiInputM[2].OnUnitNumChange += Tutorial02Start;
        
        AudioManager.Instance.PlayBgm(true, 1);


    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse2)&&count ==2)
        {
            CamMove();
        }
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
            case 3:
                StartCoroutine(Tutorial04());
                break;
            case 4:
                StartCoroutine(Tutorial05());
                break;
            case 6:
                StartCoroutine(Tutorial07());
                break;
            case 7:
                EndTutorial();
                break;
        }
    }


    public void OnClickBtn()
    {
        Off();
        count++;
        ClickBtn();
    }

    private void CamMove()
    {
        StartCoroutine(Tutorial03());
    }

    private void Tutori()
    {
        Sequence txt = DOTween.Sequence();
        txt.SetUpdate(true);
        txt.Append(text.DOText(tuto[count], tutoNum[count]).SetEase(Ease.Linear));
        
    }

    private void Tutorial02Start(int value)
    {
        StartCoroutine(Tutorial06());
    }

    IEnumerator Tutorial01()
    {
        yield return new WaitForSecondsRealtime(2);
        
        On();
        Tutori();
        yield return new WaitForSecondsRealtime(tutoNum[count] + 0.5f);
        butten.SetActive(true);

    }
    IEnumerator Tutorial02() 
    {
        
        On();
        Tutori();
        yield return new WaitForSecondsRealtime(tutoNum[count] + 0.5f);
        butten.SetActive(true);

    }
    IEnumerator Tutorial03()
    {
        //yield return new WaitForSecondsRealtime(3);
        On();
        Tutori();
        yield return new WaitForSecondsRealtime(tutoNum[count] + 0.5f);
        butten.SetActive(true);
        
    }
    IEnumerator Tutorial04()
    {
        StartCoroutine(camMove.EnemyCamMove());
        yield return new WaitForSecondsRealtime(2 + 0.5f);
        On();
        Tutori();
        yield return new WaitForSecondsRealtime(tutoNum[count] + 0.5f);
        butten.SetActive(true);

    }
    IEnumerator Tutorial05()
    {
        StartCoroutine(camMove.PlayerCamMove());
        yield return new WaitForSecondsRealtime(3);
        On();
        Tutori();
        yield return new WaitForSecondsRealtime(tutoNum[count] + 0.5f);
        butten.SetActive(true);

    }
    IEnumerator Tutorial06()
    {
        On();
        Tutori();
        yield return new WaitForSecondsRealtime(tutoNum[count] + 0.5f);
        butten.SetActive(true);

        uiInputM[0].OnUnitNumChange -= Tutorial02Start;
        uiInputM[1].OnUnitNumChange -= Tutorial02Start;
        uiInputM[2].OnUnitNumChange -= Tutorial02Start;
    }
    IEnumerator Tutorial07()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        On();
        Tutori();
        yield return new WaitForSecondsRealtime(tutoNum[count] + 0.5f);
        butten.SetActive(true);
    }

    private void EndTutorial()
    {
        blackScene.ExitScene(4);
        //SceneManager.LoadScene(4);
    }

}
