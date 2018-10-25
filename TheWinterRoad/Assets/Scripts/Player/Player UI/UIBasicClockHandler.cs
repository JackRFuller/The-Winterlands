using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBasicClockHandler : Entity
{
    public Vec3Lerping lerpingAttributes;

    [SerializeField]
    private Transform clockFaceTransform;

    private void Start()
    {
        GameManager.Instance.TimeManager.Midday += TriggerNewTimeOfDay;
        GameManager.Instance.TimeManager.Dusk += TriggerNewTimeOfDay;
        GameManager.Instance.TimeManager.Dawn += TriggerNewTimeOfDay;
        GameManager.Instance.TimeManager.Midnight += TriggerNewTimeOfDay;

        this.enabled = false;
    }

    private void Update()
    {
        RotateClock();
    }

    private void TriggerNewTimeOfDay()
    {
        Debug.Log("New Time of Day");

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
                this.enabled = false;
            }

        }
    }
}
