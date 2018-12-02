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
    public bool isBurnable;
    public bool isEdible;
    public float healthRenewalAmount;
    public float burnTime;
    public float burnIntensity;
    public float pickupTime;
    
}
