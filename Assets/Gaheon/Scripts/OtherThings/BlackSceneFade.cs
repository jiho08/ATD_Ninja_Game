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
    
    [SerializeField] private SaveSo saveSo;

    public float fadeSpeed = 0.25f;
    private float _timeSet;

    void Start()
    {
        Time.timeScale = 1;
        FadeOutCo();
        _timeSet = Time.deltaTime;
    }


    void FadeInCo(int scneneNum)
    {
        blackPanel.color = new Color(0f, 0f, 0f, 0f);
        //blackPanel.transform.localScale = Vector3.one;
        Sequence seq1 = DOTween.Sequence();
        seq1.SetUpdate(true);
        seq1.Append(blackPanel.DOFade(1, 1f)).OnComplete(() => SceneManager.LoadScene(scneneNum));

        //while (blackPanel.color.a <= 1)
        //{

        //    blackPanel.color += new Color(0, 0, 0, _timeSet * fadeSpeed);
        //}

     
    }

    void FadeOutCo()
    {

        blackPanel.color = new Color(0f, 0f, 0f, 1f);
        //while (blackPanel.color.a >= 0)
        //{
        //    blackPanel.color -= new Color(0, 0, 0, Time.deltaTime * fadeSpeed);
        //    yield return null;
        //}
        blackPanel.DOFade(0, 1f);

        //blackPanel.transform.localScale = Vector3.zero;
    }

    public void ExitScene(int scneneNum)
    {
        saveSo.LoadSo();
        FadeInCo(scneneNum);
        AudioManager.Instance.PlaySfx(AudioManager.Sfx.Btn);
    }
}