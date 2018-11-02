using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private float worldTime;
    private string formattedWorldTime;

    public float WorldTime
    {
        get
        {
            return worldTime;
        }
    }
    public string FormattedWorldTime
    {
        get
        {
            return formattedWorldTime;
        }
    }

    //Events
    public event Action NewDay;
    public event Action NewDayPeriod;

    private int dayIndex;
    private TimePeriods.DayPeriods dayPeriod;
    private TimePeriods.DaysOfWeek dayOfWeek;
    public TimePeriods.DaysOfWeek DayOfWeek
    {
        get
        {
            return dayOfWeek;
        }
    }

    private void Start()
    {
        NewDay += IncrementDay;

        dayOfWeek = TimePeriods.DaysOfWeek.Sunday;
        dayPeriod = TimePeriods.DayPeriods.Dawn;

        //Set World Time to Dawn
        worldTime = 108000;
    }

    private void Update()
    {
        RunWorldTime();
        TriggerTimeOfDayEvent();
    }

    private void RunWorldTime()
    {
        //A day should run for about 16mins
        worldTime += Time.fixedDeltaTime * 50;

        if (worldTime >= 432000)
        {
            worldTime = 0;

            NewDay();
        }            

        int minutes = (int)(worldTime / 60) % 60;
        int hours = (int)(worldTime / 3600) % 24;

        formattedWorldTime = string.Format("{0:00}:{1:00}", hours, minutes);
    }

    private void TriggerTimeOfDayEvent()
    {
        TimePeriods.DayPeriods tempDayPeriod = dayPeriod;

        switch(formattedWorldTime)
        {
            case "00:00": 
                dayPeriod = TimePeriods.DayPeriods.Midnight;
                break;
            case "06:00":
                dayPeriod = TimePeriods.DayPeriods.Dawn;
                break;
            case "12:00":
                dayPeriod = TimePeriods.DayPeriods.Midday;
                break;
            case "18:00":
                dayPeriod = TimePeriods.DayPeriods.Dusk;
                break;
        }

        if (tempDayPeriod != dayPeriod)
            if(NewDayPeriod != null)
                NewDayPeriod();
    }

    private void IncrementDay()
    {
        dayIndex++;
        if (dayIndex > 6)
            dayIndex = 0;

        dayOfWeek = (TimePeriods.DaysOfWeek)dayIndex;
    }
}
