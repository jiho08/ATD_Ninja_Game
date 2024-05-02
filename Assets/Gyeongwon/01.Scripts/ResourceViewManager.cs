using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourceViewManager : MonoBehaviour
{
    public TextMeshProUGUI ResourceText;

    private void Start()
    {
        ResourceText.text = $"ฐํรถ {ResourceManager.instance.GetRsc()}";
    }
}

