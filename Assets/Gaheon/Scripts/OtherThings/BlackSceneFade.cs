using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackSceneFade : MonoBehaviour
{
    Image blackPanel;
    private void Start()
    {
        blackPanel = GetComponent<Image>();
        Debug.Log("asdasd");
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        blackPanel.color -= new Color(0f, 0f, 0f, 0.125f);
        yield return new WaitForSecondsRealtime(0.125f);
        blackPanel.color -= new Color(0f, 0f, 0f, 0.125f);
        yield return new WaitForSecondsRealtime(0.125f);
        blackPanel.color -= new Color(0f, 0f, 0f, 0.125f);
        yield return new WaitForSecondsRealtime(0.125f);
        blackPanel.color -= new Color(0f, 0f, 0f, 0.125f);
        yield return new WaitForSecondsRealtime(0.125f);
        blackPanel.color -= new Color(0f, 0f, 0f, 0.125f);
        yield return new WaitForSecondsRealtime(0.125f);
        blackPanel.color -= new Color(0f, 0f, 0f, 0.125f);
        yield return new WaitForSecondsRealtime(0.125f);
        blackPanel.color -= new Color(0f, 0f, 0f, 0.125f);
        yield return new WaitForSecondsRealtime(0.125f);
        blackPanel.color -= new Color(0f, 0f, 0f, 0.125f);
        gameObject.SetActive(false);
    }
    IEnumerator FadeIn()
    {
        blackPanel.color += new Color(0f, 0f, 0f, 0.125f);
        yield return new WaitForSecondsRealtime(0.125f);
        blackPanel.color += new Color(0f, 0f, 0f, 0.125f);
        yield return new WaitForSecondsRealtime(0.125f);
        blackPanel.color += new Color(0f, 0f, 0f, 0.125f);
        yield return new WaitForSecondsRealtime(0.125f);
        blackPanel.color += new Color(0f, 0f, 0f, 0.125f);
        yield return new WaitForSecondsRealtime(0.125f);
        blackPanel.color += new Color(0f, 0f, 0f, 0.125f);
        yield return new WaitForSecondsRealtime(0.125f);
        blackPanel.color += new Color(0f, 0f, 0f, 0.125f);
        yield return new WaitForSecondsRealtime(0.125f);
        blackPanel.color += new Color(0f, 0f, 0f, 0.125f);
        yield return new WaitForSecondsRealtime(0.125f);
        blackPanel.color += new Color(0f, 0f, 0f, 0.125f);
        gameObject.SetActive(false);
    }
}
