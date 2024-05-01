using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


public class BlackSceneFade : MonoBehaviour
{
    Image blackPanel;

    public float fadeSpeed = 1.5f;

    void Start()
    {
        blackPanel = GetComponent<Image>();
        blackPanel.color = new Color(0f, 0f, 0f, 1f);
        FadeOut();
    }

    void FadeIn()
    {
        StartCoroutine(FadeInCo());
    }
    void FadeOut()
    {
        StartCoroutine(FadeOutCo());
    }

    IEnumerator FadeInCo()
    {
        while (blackPanel.color.a < 1)
        {
            blackPanel.color += new Color(0, 0, 0, Time.deltaTime * fadeSpeed);
            yield return null;
        }
        gameObject.SetActive(true);
    }

    IEnumerator FadeOutCo()
    {
        while (blackPanel.color.a > 0)
        {
            blackPanel.color -= new Color(0, 0, 0, Time.deltaTime * fadeSpeed);
            yield return null;
        }
        gameObject.SetActive(false);
    }
}
