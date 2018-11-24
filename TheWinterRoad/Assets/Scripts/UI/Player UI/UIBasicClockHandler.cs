using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIBasicClockHandler : Entity
{
    private TimeManager timeManager;

    public Vec3Lerping lerpingAttributes;

    [SerializeField]
    private Transform clockFaceTransform;
    [SerializeField]
    private TMP_Text dayOfWeekText;
    [SerializeField]
    private TMP_Text timeOfTheDayText;

    private void Start()
    {
        timeManager = GameManager.Instance.TimeManager;
        timeManager.NewDayPeriod += TriggerNewTimeOfDay;
        timeManager.NewDay += TriggerNewDay;

        dayOfWeekText.text = timeManager.DayOfWeek.ToString();
    }

    private void Update()
    {
        FormatTime();
        RotateClock();
    }

    private void FormatTime()
    {
        timeOfTheDayText.text = timeManager.WorldTime.ToString("HH" + ":" + "mm");
    }

    private void TriggerNewTimeOfDay()
    {
        lerpingAttributes.lerpStartPosition = clockFaceTransform.eulerAngles;
        lerpingAttributes.lerpTargetPosition = new Vector3(lerpingAttributes.lerpStartPosition.x,
                                                           lerpingAttributes.lerpStartPosition.y,
                                                           lerpingAttributes.lerpStartPosition.z - 90);

        lerpingAttributes.lerpTimeStarted = Time.time;
        lerpingAttributes.isLerping = true;
        this.enabled = true;
    }

    private void RotateClock()
    {
        if(lerpingAttributes.isLerping)
        {
            float timeSinceStarted = Time.time - lerpingAttributes.lerpTimeStarted;
            float percentageComplete = timeSinceStarted / lerpingAttributes.lerpingSpeed;

            Vector3 newRotation = Vector3.Lerp(lerpingAttributes.lerpStartPosition, lerpingAttributes.lerpTargetPosition, lerpingAttributes.lerpAnimCurve.Evaluate(percentageComplete));
            clockFaceTransform.eulerAngles = newRotation;

            if(percentageComplete >= 1.0f)
            {
                clockFaceTransform.eulerAngles = new Vector3(0, 0, clockFaceTransform.eulerAngles.z);
                lerpingAttributes.isLerping = false;                
            }

        }
    }

    private void TriggerNewDay()
    {
        dayOfWeekText.text = timeManager.DayOfWeek.ToString();
    }
}
