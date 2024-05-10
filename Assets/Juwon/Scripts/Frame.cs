using System;
using UnityEngine;

public class Frame : MonoBehaviour
{
    [SerializeField] private int frameValue;
    private void Awake()
    {
        Application.targetFrameRate = frameValue;
    }
}
