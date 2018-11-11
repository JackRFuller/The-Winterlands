using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryItem",menuName = "Data/InventoryItem", order = 1)]
public class InventoryItemData : ScriptableObject
{
    public string itemName;
    [TextArea]
    public string itemDescription;
    public Sprite itemIcon;
    public GameObject itemPrefab;
    public bool hasUnlockedTool;
    public bool isDropable;
}
