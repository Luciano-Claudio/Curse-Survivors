using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public static TimerController instance;

    public Text timeCounter;
    public int minutes;
    public int seconds;

    private TimeSpan timePlaying;
    private bool timerGoing;

    private float elapsedTime;


    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        timeCounter.text = "00:00";
        timerGoing = false;
        BeginTimer();
    }

    public void BeginTimer()
    {
        timerGoing = true;
        elapsedTime = 0f;

        StartCoroutine(UpdateTimer());
    }

    public void EndTimer()
    {
        timerGoing = false;
    }

    IEnumerator UpdateTimer()
    {
        while (timerGoing)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);

            timeCounter.text = timePlaying.ToString(@"mm\:ss");
            minutes = (int)timePlaying.TotalMinutes;
            seconds = (int)timePlaying.TotalSeconds;
            if (minutes > 0)
                seconds -= minutes * 60;
            yield return null;
        }
    }

}
