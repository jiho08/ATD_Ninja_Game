using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourceView : MonoBehaviour
{
    public TextMeshProUGUI ResourceText;
    void Start()
    {
        ResourceText.text = $"ฐํรถ : {ResourceManager.instance.GetRsc()}";
    }
}
