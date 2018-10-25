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
    public event Action Midday;
    public event Action Midnight;
    public event Action Dawn;
    public event Action Dusk;

    private void Update()
    {
        RunWorldTime();
        TriggerTimeOfDayEvent();
    }

    private void RunWorldTime()
    {
        worldTime += Time.fixedDeltaTime * 60;

        int minutes = (int)(worldTime / 60) % 60;
        int hours = (int)(worldTime / 3600) % 24;

        formattedWorldTime = string.Format("{0:00}:{1:00}", hours, minutes);

        Debug.Log(formattedWorldTime);
    }

    private void TriggerTimeOfDayEvent()
    {
        switch(formattedWorldTime)
        {
            case "00:00":
                if (Midnight != null)
                    Midnight();
                break;
            case "06:00":
                if (Dawn != null)
                    Dawn();
                break;
            case "12:00":
                if (Midday != null)
                    Midday();
                break;
            case "18:00":
                if (Dusk != null)
                    Dusk();
                break;
        }
    }

    


}
