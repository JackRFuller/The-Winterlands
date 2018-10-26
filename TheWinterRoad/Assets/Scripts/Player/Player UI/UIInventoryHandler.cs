using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryHandler : Entity
{
    protected Animator inventoryAnimController;

    protected InventoryState inventoryState;
    protected enum InventoryState
    {
        Hidden,
        Visible,
    }

    [Header("UI Components")]
    [SerializeField]
    private Image[] inventoryItemIconImages;
    [SerializeField]
    private UIInventoryButtonHandler[] inventoryButtonHandlers;

    private void Start()
    {
        inventoryAnimController = GetComponent<Animator>();
        inventoryState = InventoryState.Hidden;
    }

    public void SetupInventory(PlayerView playerView)
    {
        playerView.PlayerInventory.ItemAddedToInventory += AddItemToInventoryUI;
    }

    private void AddItemToInventoryUI(InventoryItem item, int inventoryIndex)
    {
        int index = inventoryIndex - 1;

        inventoryItemIconImages[index].sprite = item.itemIcon;
        inventoryItemIconImages[index].enabled = true;
    }

    #region InventoryShowingAndHidingInUI

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

    #endregion
}
