using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : Entity
{
    private Transform playerTransform;
    public Transform PlayerTransform
    {
        get
        {
            return playerTransform;
        }
    }

    private void Start()
    {
        playerTransform = GameManager.Instance.PlayerView.transform;
    }
}
