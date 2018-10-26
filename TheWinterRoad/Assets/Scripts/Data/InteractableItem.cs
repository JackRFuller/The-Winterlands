using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InteractableItem",menuName = "Data/InteractableItem",order = 1)]
public class InteractableItem : ScriptableObject
{
    public InventoryItem requiredItem;
    public int quantityOfRequiredItem = 1;
    public bool hasProgressBar;
    public InventoryItem[] inventoryItems;
    [Range(0,1)]
    public int interactionAnimationIndex; //1 = Chop
}
