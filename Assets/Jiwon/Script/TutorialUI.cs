using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TutorialUI : MonoBehaviour
{
    public bool isFadeIn;
    public GameObject paner;
    public Text textUI;
    public Button Next;
    [SerializeField] GameObject nextButte;
    private Button BtnComponent;
    private int count = 0;

    
    


    //넣을 문구
    private string tuto01 = "아열2타게에 오신것을 환영합니다";
    private string tuto02 = "아 뭐라고 씨부릴지 모르겟다";
    private string tuto03 = "집에가고싶다아앜";

    private void Awake()
    {
        paner = gameObject.transform.GetChild(0).gameObject;
        BtnComponent = nextButte.GetComponent<Button>();
        FadeOut();
        
    }

    private void Start()
    {
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
        StartCoroutine(OutPut(tuto01));
    }

    public void NextBtn01() // 다음 버튼 1
    {
        NextBtn();
        Next.onClick.AddListener(() => NextBtn02());
        Invoke("TutorialUI02",1f);

    }

    private void TutorialUI02() //튜토2
    {
        FadeIn();
        StartCoroutine(OutPut(tuto02));
        //BtnComponent.onClick.AddListener(NextBtn02);
        Debug.Log(Next.onClick);

    }

    public void NextBtn02() //다음 버튼 2
    {
        NextBtn();
        Invoke("TutoralUI03", 0.5f);

    }

    private void TutoralUI03()
    {
        FadeIn();
        OutPut(tuto03);
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

}
