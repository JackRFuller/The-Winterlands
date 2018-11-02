using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InteractableItem",menuName = "Data/InteractableItem",order = 1)]
public class InteractableItemData : ScriptableObject
{
    public Interact[] interacts;
}

[System.Serializable]
public class Interact
{
    public RequiredInventoryItems requiredInventoryItem;
    public float numberofRequiredInteracts;    
    public int interactionAnimationIndex; //0 = Pickup, 1 = Chop 
    public AwardedInventoryItem[] awardedInventoryItems;
}

[System.Serializable]
public class RequiredInventoryItems
{
    public InventoryItemData requiredInventoryItem;
    public int quanityOfRequiredInventoryItem;
}

[System.Serializable]
public class AwardedInventoryItem
{
    public InventoryItemData awardedInventoryItem;
    public float[] spawnRates;
}
