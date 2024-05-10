using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinMove : MonoBehaviour
{
    private Color stdcolor = new Color(1f, 1f, 1f, 1f);
    [SerializeField] private GameObject pin;

    WorldMapManager worldMapM;

    private void Awake()
    {
        worldMapM = FindObjectOfType<WorldMapManager>();
    }


    private void Start()
    {
        StartCoroutine(Blink());
        worldMapM.OnMoving += () =>
        {
            StopAllCoroutines();
            pin.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        };
        worldMapM.NoMoving += () => { StartCoroutine(Blink()); };
    }

    private IEnumerator Blink()
    {
        Image image = pin.GetComponent<Image>();
        while (true)
        {
            while (image.color.a < 1f)
            {
                stdcolor.a += 0.1f;
                image.color = stdcolor;
                yield return new WaitForSeconds(0.075f);
            }
            yield return new WaitForSeconds(0.5f);

            while (image.color.a > 0f)
            {
                stdcolor.a -= 0.1f;
                image.color = stdcolor;
                yield return new WaitForSeconds(0.075f);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}
