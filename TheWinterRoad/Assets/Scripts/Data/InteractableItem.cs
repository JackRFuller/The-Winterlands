using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InteractableItem",menuName = "Data/InteractableItem",order = 1)]
public class InteractableItem : ScriptableObject
{
    public InteractableItemType interactType;

    public float numberOfNeededInteracts = 1;

    public InventoryItem requiredItem;
    public int quantityOfRequiredItem = 1;   
    public InventoryItem[] inventoryItems;
    [Range(0,1)]
    public int interactionAnimationIndex; //1 = Chop

    public HarvestableItem[] harvestableItems;

    
    public enum InteractableItemType
    {
        ItemPickup,
        Harvestable,
    }

}
