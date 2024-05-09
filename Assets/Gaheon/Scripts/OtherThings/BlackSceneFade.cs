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

    public float fadeSpeed = 0.25f;
    private float time;

    void Start()
    {
        StartCoroutine(FadeOutCo());
        time = Time.deltaTime;
    }

    IEnumerator FadeInCo(int scneneNum)
    {
        blackPanel.transform.localScale = Vector3.one;

        while (blackPanel.color.a < 1)
        {
            blackPanel.color += new Color(0, 0, 0,  time * fadeSpeed);
            Debug.Log(Time.deltaTime * fadeSpeed);
            yield return null;
        }

        Debug.Log("out");
        SceneManager.LoadScene(scneneNum);
    }

    IEnumerator FadeOutCo()
    {
        Time.timeScale = 1;
        blackPanel.color = new Color(0f, 0f, 0f, 1f);
        while (blackPanel.color.a > 0)
        {
            blackPanel.color -= new Color(0, 0, 0, Time.deltaTime * fadeSpeed);
            Debug.Log(Time.deltaTime * fadeSpeed);
            yield return null;
        }

        blackPanel.transform.localScale = Vector3.zero;
    }

    public void ExitScene(int scneneNum)
    {
        Debug.Log("in");
        StartCoroutine(FadeInCo(scneneNum));
        AudioManager.Instance.PlaySfx(AudioManager.Sfx.Btn);
    }
}