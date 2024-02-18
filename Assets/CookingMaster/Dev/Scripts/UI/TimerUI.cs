using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameLeftTxt;
    private void Awake()
    {
        Locator.Instance.GameManagerInstance.OnGameTimeLeft += OnGameTimeLeft;
    }

    private void OnGameTimeLeft(float time)
    {
        TimeData dateTime = new((int)time);
        gameLeftTxt.text = $"{dateTime.Minute :00} : {dateTime.Second:00}";
    }
}

public class TimeData
{
    public int Minute;
    public int Second;

    public TimeData()
    {

    }

    public TimeData(int seconds)
    {
        Minute = seconds / 60;
        Second = (seconds) - (Minute * 60);
    }
}
