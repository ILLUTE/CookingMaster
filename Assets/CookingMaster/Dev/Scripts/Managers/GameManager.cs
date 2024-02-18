using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float GameTime = 5.0f;

    private float startTime;
    private bool IsGameRunning;

    public Action<float> OnGameTimeLeft;
    public Action OnGameOver;

    private void Start()
    {
        startTime = Time.time;
        IsGameRunning = true;
    }
    private void Update()
    {
        if (!IsGameRunning) return;
        if (Time.time - startTime < GameTime)
        {
            IsGameRunning = true;
            OnGameTimeLeft?.Invoke(GameTime - (Time.time - startTime));
        }
        else
        {
            IsGameRunning = false;
            OnGameOver?.Invoke();
        }
    }
}
