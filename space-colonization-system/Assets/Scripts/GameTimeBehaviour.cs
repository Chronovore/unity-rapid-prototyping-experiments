using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using SpaceColonizationSystem.Services;
using TMPro;
using UnityEngine.UI;

public class GameTimeBehaviour : MonoBehaviour
{
    //todo:  Make this a nice visual date selector for designers.
    public float dayDurationInSeconds = 3.0f;
    public float gameTimeMultiplier = 0.0f;
    public bool isPaused = true;
    public int initialGameDay;
    public float initialDayProgress = 0.4f;
    public Text gameTimeUiTextElement;
    public int initialGameYear = 1;
    public int weeksPerMonth = 4;
    public string[] dayNames;
    public string[] monthNames;

    private GameDateService _gameDateService;
    
    private void Start()
    {
        var startDate = new GameDate(initialGameDay, initialDayProgress, initialGameYear);
        _gameDateService = new GameDateService(new GameDateConfig(startDate, weeksPerMonth, dayNames, monthNames));
    }

    private void Update()
    {
        if (isPaused) return;
        
        _gameDateService.Add(Time.deltaTime * gameTimeMultiplier / dayDurationInSeconds);
        gameTimeUiTextElement.text = GetFullDateString(_gameDateService.FullGameDate);
    }

    private static string GetFullDateString(FullGameDate date)
    {
        // future: add internationalization
        return $"{date.DayName} {date.DayOfMonth} {date.MonthName} {date.Year}";
    }
}