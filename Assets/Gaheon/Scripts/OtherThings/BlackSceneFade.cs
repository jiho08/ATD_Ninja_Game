using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class BlackSceneFade : MonoBehaviour
{
    [SerializeField] Image blackPanel;

    public float fadeSpeed = 1f;

    void Start()
    {
        StartCoroutine(FadeOutCo());
    }

    IEnumerator FadeInCo(string sceneName)
    {
        blackPanel.transform.localScale = Vector3.one;
        while (blackPanel.color.a < 1)
        {
            blackPanel.color += new Color(0, 0, 0, Time.deltaTime * fadeSpeed);
            yield return null;
        }
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator FadeOutCo()
    {
        blackPanel.color = new Color(0f, 0f, 0f, 1f);
        while (blackPanel.color.a > 0)
        {
            blackPanel.color -= new Color(0, 0, 0, Time.deltaTime * fadeSpeed);
            yield return null;
        }
        blackPanel.transform.localScale = Vector3.zero;
    }
    public void ExitScene(string scneneName)
    {
        StartCoroutine(FadeInCo(scneneName));
    }
}
