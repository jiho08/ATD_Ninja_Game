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

    
    


    //���� ����
    private string tuto01 = "�ƿ�2Ÿ�Կ� ���Ű��� ȯ���մϴ�";
    private string tuto02 = "�� ����� ���θ��� �𸣰ٴ�";
    private string tuto03 = "��������ʹپƝ�";

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
    private void TutorialUI01() //Ʃ�丮�� 1
    {
        FadeIn();
        StartCoroutine(OutPut(tuto01));
    }

    public void NextBtn01() // ���� ��ư 1
    {
        NextBtn();
        Next.onClick.AddListener(() => NextBtn02());
        Invoke("TutorialUI02",1f);

    }

    private void TutorialUI02() //Ʃ��2
    {
        FadeIn();
        StartCoroutine(OutPut(tuto02));
        //BtnComponent.onClick.AddListener(NextBtn02);
        Debug.Log(Next.onClick);

    }

    public void NextBtn02() //���� ��ư 2
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
