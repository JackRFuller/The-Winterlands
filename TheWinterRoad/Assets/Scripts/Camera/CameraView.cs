using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : Entity
{
    [SerializeField]
    private Transform playerTransform;
    public Transform PlayerTransform
    {
        get
        {
            return playerTransform;
        }
    }
}
