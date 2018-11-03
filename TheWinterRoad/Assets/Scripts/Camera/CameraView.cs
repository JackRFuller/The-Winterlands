using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : Entity
{
    private CameraShake cameraShake;

    private Transform playerTransform;
    public Transform PlayerTransform
    {
        get
        {
            return playerTransform;
        }
    }

    public CameraShake CameraShake
    {
        get
        {
            return cameraShake;
        }
    }

    private void Start()
    {
        playerTransform = GameManager.Instance.PlayerView.transform;
    }
}
