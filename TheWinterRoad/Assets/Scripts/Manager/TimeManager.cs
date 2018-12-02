using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeManager : MonoBehaviour
{

    private  DateTime worldTime;
    public DateTime WorldTime {get{return worldTime;}}


    public event Action NewMinute;
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
    public TimePeriods.DayPeriods DayPeriod
    {
        get
        {
            return dayPeriod;
        }
    }

    private void Start()
    {
        NewDay += IncrementDay;

        dayOfWeek = TimePeriods.DaysOfWeek.Sunday;
        dayPeriod = TimePeriods.DayPeriods.Dawn;      

        worldTime = new DateTime(1435, 1,1,6,0,0);
        
        StartCoroutine(IncrementTime());
    }

    private IEnumerator IncrementTime()
    {
        while(true)
        {
            DateTime oldWorldTime = worldTime;

            yield return new WaitForSecondsRealtime(1f);
            DateTime currentTime = worldTime.AddMinutes(1.0f);
            worldTime = currentTime;
            
            if(NewMinute != null)
                NewMinute();

            TriggerTimeOfDayEvent();

            if(oldWorldTime.Day != worldTime.Day)
            {
                if(NewDay != null)
                    NewDay();
            }
        }
    }

    private void TriggerTimeOfDayEvent()
    {
        string formattedTime = worldTime.ToString("HH" + ":" + "mm");

        TimePeriods.DayPeriods tempDayPeriod = dayPeriod;

        switch(formattedTime)
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
