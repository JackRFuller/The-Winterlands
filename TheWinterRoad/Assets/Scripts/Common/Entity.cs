using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    protected void SetPosition(Vector3 newPosition)
    {
        transform.position = newPosition;
    }

    protected void SetRotation(Quaternion newRotation)
    {
        transform.rotation = newRotation;
    }

}
