using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class PinMove : MonoBehaviour
{
    private Color color = new Color(1f, 1f, 1f, 1f);
    [SerializeField] private Transform[] stages;
    WorldMapManager worldMapM;
    [SerializeField] private GameObject pin;

    private void Awake()
    {
        worldMapM = GetComponent<WorldMapManager>();
    }


    private void Start()
    {
        StartCoroutine(Blink());
    }

    private IEnumerator Blink()
    {
        while (true)
        {
            while (pin.GetComponent<Image>().color.a < 1f)
            {
                color.a += 0.1f;
                pin.GetComponent<Image>().color = color;
                yield return new WaitForSeconds(0.05f);
            }
            yield return new WaitForSeconds(0.5f);

            while (pin.GetComponent<Image>().color.a > 0f)
            {
                color.a -= 0.1f;
                pin.GetComponent<Image>().color = color;
                yield return new WaitForSeconds(0.05f);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}
