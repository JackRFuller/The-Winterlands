using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementHandler : CameraHandler
{
    [SerializeField]
    private Vector3 cameraOffset;


	// Update is called once per frame
	void LateUpdate ()
    {
        Vector3 cameraPosition = cameraView.PlayerTransform.position;
        cameraPosition += cameraOffset;

        transform.position = cameraPosition;

	}
}
