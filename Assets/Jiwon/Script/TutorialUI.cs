using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;

public class TutorialUI : MonoBehaviour
{
    public bool isFadeIn;
    public GameObject paner;
    public Text textUI;
    public Button Next;
    [SerializeField] GameObject nextButte;
    private Button BtnComponent;
    private int count = 0;
    [SerializeField]
    private GameObject mouse;
    private GameObject pos;
    [SerializeField]
    private GameObject pos2;





    //넣을 문구
    private string tuto01 = "아열2타게에 오신것을 환영합니다";
    private string tuto02 = "아 뭐라고 씨부릴지 모르겟다";
    private string tuto03 = "집에가고싶다아앜";
    private string tuto04 = "응 아잇 어";

    private void Awake()
    {
        paner = gameObject.transform.GetChild(0).gameObject;
        BtnComponent = nextButte.GetComponent<Button>();
        FadeOut();
        pos = GameObject.Find("Canvas").transform.GetChild(0).gameObject;

    }

    private void Start()
    {
        mouse.SetActive(true);
        nextButte.SetActive(false);
        Invoke("TutorialUI01", 2f);

    }

    public void FadeOut()
    {

        Time.timeScale = 1;
        isFadeIn = false; 
        paner.SetActive(false);

    }
    public void FadeIn()
    {
        Debug.Log("초기화");
        textUI.text = " ";
        Time.timeScale = 0;
        isFadeIn = true;
        paner.SetActive(true);
    }

    private void NextBtn()
    {
        textUI.text = " ";
        nextButte.SetActive(false);
        FadeOut();
    }
    private void TutorialUI01() //튜토리얼 1
    {
        FadeIn();
        MousseMove();

        StartCoroutine(OutPut(tuto01));
    }

    public void NextBtn01() // 다음 버튼 1
    {
        NextBtn();
        Next.onClick.AddListener(() => NextBtn02());
        Invoke("TutorialUI02", 1f);

    }

    private void TutorialUI02() //튜토2
    {
        FadeIn();
        StartCoroutine(OutPut(tuto02));
        //BtnComponent.onClick.AddListener(NextBtn02);

    }

    public void NextBtn02() //다음 버튼 2
    {
        NextBtn();
        Next.onClick.AddListener(() => NextBtn03());
        Invoke("TutoralUI03", 0.5f);

    }

    private void TutoralUI03()
    {
        FadeIn();
        StartCoroutine(OutPut(tuto03));
    }

    public void NextBtn03()
    {
        NextBtn();
        Next.onClick.AddListener(() => NextBtn04());
        Invoke("TutoralUI04", 0.5f);
    }

    private void TutoralUI04()
    {
        Debug.Log("시이발");
        FadeIn();
        StartCoroutine(OutPut(tuto04));
    }

    public void NextBtn04()
    {
        FadeOut();
    }


    private IEnumerator OutPut(string str)
    {

        for (int i = 0; i < str.Length; ++i)
        {
            textUI.text += str[i];
            yield return new WaitForSecondsRealtime(0.15f);

        }
        yield return new WaitForSecondsRealtime(1);
        nextButte.SetActive(true);
    }

    private void MousseMove()
    {
        mouse.SetActive(true);
        Sequence seq = DOTween.Sequence();
        seq.SetUpdate(true); //이쇄끼 있어야 타임스케일 0일때도 실행됩니다.
        seq.SetLoops(3, LoopType.Restart);
        seq.Append(mouse.transform.DOMove(pos.transform.position, 1));
        seq.AppendInterval(0.25f);
        seq.Append(mouse.transform.DOMove(pos2.transform.position, 1));
    }

}
