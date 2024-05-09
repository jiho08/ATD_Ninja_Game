using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinMove : MonoBehaviour
{
    private Color color = new Color(1f, 1f, 1f, 1f);
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
        worldMapM.NoMoving += () => { StartCoroutine(Blink());};
    }
 
    private IEnumerator Blink()
    {
        while (true)
        {
            while (pin.GetComponent<Image>().color.a < 1f)
            {
                color.a += 0.1f;
                pin.GetComponent<Image>().color = color;
                yield return new WaitForSeconds(0.075f);
            }
            yield return new WaitForSeconds(0.5f);

            while (pin.GetComponent<Image>().color.a > 0f)
            {
                color.a -= 0.1f;
                pin.GetComponent<Image>().color = color;
                yield return new WaitForSeconds(0.075f);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}
