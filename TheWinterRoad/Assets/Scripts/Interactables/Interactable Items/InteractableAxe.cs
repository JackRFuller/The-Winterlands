using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableAxe : Interactable
{
    public override void InteractOne()
    {
        playerView.PlayerInventory.AddItemToInventory(interactableData.interacts[interactIndex].awardedInventoryItems[0].awardedInventoryItem);
        this.gameObject.SetActive(false);
    }
}
