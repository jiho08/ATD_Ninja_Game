using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwningManager : MonoBehaviour
{
    [SerializeField] GameObject ktxButton;
    [SerializeField] GameObject line1Button;
    [SerializeField] OwningUnitSO owningUnitSO;
    void Start()
    {
        ktxButton.SetActive(owningUnitSO.OwningKTX);
        line1Button.SetActive(owningUnitSO.OwningLine1);
    }
}
