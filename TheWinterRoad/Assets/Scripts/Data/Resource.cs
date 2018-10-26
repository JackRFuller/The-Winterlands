using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Resource", menuName = "Data/Resource", order = 1)]
public class Resource : ScriptableObject
{
    public AssociatedTool associatedTool;

    public enum AssociatedTool
    {
        Hands,
        Axe,
        Shovel,
    }
}
