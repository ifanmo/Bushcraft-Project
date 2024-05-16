using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameTimerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameTimerText;
    public event EventHandler OnGameOver;

    public static GameTimerUI Instance { get; private set; }

    private float gameStopWatch = 60f;
    private float minutes;
    private float seconds;

    private void Awake()
    {
        Instance = this;
    }

    //The parsing of the timer is credited to AIA |YouTube| How to EASILY make a TIMER in Unity https://www.youtube.com/watch?v=27uKJvOpdYw&t=82s 
    void Update()
    {
        gameStopWatch -= Time.deltaTime;
        minutes = Mathf.FloorToInt(gameStopWatch / 60);
        seconds = Mathf.FloorToInt(gameStopWatch % 60);
        gameTimerText.text = "Time: " +  minutes.ToString() + ":" + seconds.ToString();

        if(gameStopWatch <= 0)
        {
            OnGameOver?.Invoke(this, EventArgs.Empty);
        }
    }
}
