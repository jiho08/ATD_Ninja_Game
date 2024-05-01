using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialUI : MonoBehaviour
{
    public bool isFadeIn;
    public GameObject paner;
    public Text textUI;

    //���� ����
    private string tuto = "�ƿ�2Ÿ�Կ� ���Ű��� ȯ���մϴ�";

    private void Awake()
    {
        paner = gameObject.transform.GetChild(0).gameObject;
        
    }

    private void Start()
    {
        FadeOut();
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
        TutorialUI01();
    }
    private void TutorialUI01()
    {
        StartCoroutine(QWER(tuto));
    }

    private IEnumerator QWER(string str)
    {
        for (int i = 0; i < str.Length; ++i)
        {
            textUI.text += str[i];
            yield return new WaitForSecondsRealtime(0.15f);
        }
    }

}
