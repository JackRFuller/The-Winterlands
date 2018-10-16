using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryHandler : Entity
{
    protected Animator inventoryAnimController;

    protected InventoryState inventoryState;
    protected enum InventoryState
    {
        Hidden,
        Visible,
    }

    private void Start()
    {
        inventoryAnimController = GetComponent<Animator>();
        inventoryState = InventoryState.Hidden;
    }

    public virtual void ToggleInventory()
    {
        switch (inventoryState)
        {
            case InventoryState.Hidden:
                ShowInventory();
                break;
            case InventoryState.Visible:
                HideInventory();
                break;
        }

    }

    protected virtual void ShowInventory()
    {
        inventoryState = InventoryState.Visible;

        if(inventoryAnimController.enabled == false)
        {
            inventoryAnimController.enabled = true;
            return;
        }

        inventoryAnimController.SetBool("ShowInventory", true);
    }

    protected virtual void HideInventory()
    {
        inventoryState = InventoryState.Hidden;
        inventoryAnimController.SetBool("ShowInventory", false);
    }
}
