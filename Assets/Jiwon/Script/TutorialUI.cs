using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] private GameObject paner;
    [SerializeField] private GameObject butten;
    [SerializeField] private Text text;

    [SerializeField] private string[] tuto;

    private int count;

    private void Awake()
    {
        count = 0;
    }
    private void Start()
    {
        Off();
        StartCoroutine(Tutorial());
    }

    private void On()
    {
        Time.timeScale = 0;
        paner.SetActive(true);
        butten.SetActive(true);
        text.gameObject.SetActive(true);
    }
    private void Off()
    {
        Time.timeScale = 1;
        paner.SetActive(false);
        butten.SetActive(false);
        text.gameObject.SetActive(false);
    }
    IEnumerator Tutorial()
    {
        yield return new WaitForSecondsRealtime(2);
        On();
        Sequence txt = DOTween.Sequence();
        txt.SetUpdate(true);
        txt.Append(text.DOText(tuto[count], 1));

    }

}
