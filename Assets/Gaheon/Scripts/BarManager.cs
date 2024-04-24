using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarManager : MonoBehaviour
{
    [SerializeField] Image currentHpBar;
    [SerializeField] Image previewHpBar;
    [SerializeField] Image currentStrBar;
    [SerializeField] Image previewStrBar;
    [SerializeField] Image currentSpeedBar;
    [SerializeField] Image previewSpeedBar;

    //int[] level1States = {}
    void Start()
    {
        //Debug.Log(currentHpBar.rectTransform.sizeDelta);
    }

    void Update()
    {
        
    }

}
