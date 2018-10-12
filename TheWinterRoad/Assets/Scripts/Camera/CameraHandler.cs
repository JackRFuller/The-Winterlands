using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : Entity
{
    protected CameraView cameraView;

    protected virtual void Start()
    {
        cameraView = GetComponent<CameraView>();
    }
	
}
