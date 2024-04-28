using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Oddmentmanager : MonoBehaviour
{
    int currentOddments;
    public TextMeshProUGUI oddmentsText;

    private void Start()
    {
        currentOddments = ResourceManager.instance.GetRsc();
        oddmentsText.text = currentOddments.ToString();
    }
    private void Update()
    {
        currentOddments = ResourceManager.instance.GetRsc();
        oddmentsText.text = currentOddments.ToString();
    }
}
