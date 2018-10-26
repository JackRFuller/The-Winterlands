using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableAxe : Interactable
{
    public override void Interact(PlayerView _playerView)
    {
        _playerView.PlayerInventory.AddItemToInventory(interactable.inventoryItems[0]);
        this.gameObject.SetActive(false);
    }
}
