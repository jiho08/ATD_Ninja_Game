using System;
using UnityEngine;
using UnityEngine.Events;

public class MainCore : MonoBehaviour
{
    [SerializeField] UnityEvent OnGameOver;
    private HealthManager _health;
    private bool isGameOver = true;

    private void Awake()
    {
        _health = GetComponent<HealthManager>();
    }

    private void LateUpdate()
    {
        if (_health.Health <= 0 && isGameOver)
        {
            OnGameOver?.Invoke();
            isGameOver = false;
        }
    }
}
