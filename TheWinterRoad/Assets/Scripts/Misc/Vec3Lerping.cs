using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Vec3Lerping
{
    [HideInInspector]
    public bool isLerping;
    public float lerpingSpeed;
    [HideInInspector]
    public float lerpTimeStarted;
    [HideInInspector]
    public Vector3 lerpStartPosition;
    [HideInInspector]
    public Vector3 lerpTargetPosition;
    public AnimationCurve lerpAnimCurve;
}
