using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIInventoryHandler : Entity
{
    private PlayerView playerView;

    protected Animator inventoryAnimController;

    private List<InventoryItemData> inventory;
    private int currentSelectedItemIndex;

    protected InventoryState inventoryState;
    protected enum InventoryState
    {
        Hidden,
        Visible,
    }

    [Header("Item Description UI Components")]
    [SerializeField]
    private GameObject itemDescriptionObject;
    [SerializeField]
    private TMP_Text itemNameText;
    [SerializeField]
    private TMP_Text itemDescriptionText;
    [SerializeField]
    private Image itemIconImage;
    [SerializeField]
    private Button itemDropButton;

    [Header("Item Button Components")]
    [SerializeField]
    private Image[] inventoryItemIconImages;
    [SerializeField]
    private UIInventoryButtonHandler[] inventoryButtonHandlers;

    public void SetupInventory(PlayerView _playerView)
    {
        playerView = _playerView;
        playerView.PlayerInventory.InventoryUpdated += UpdateInventoryUI;

        inventory = new List<InventoryItemData>();
        inventoryAnimController = GetComponent<Animator>();
        inventoryState = InventoryState.Hidden;

        for (int i = 0; i < inventoryButtonHandlers.Length; i++)
        {
            inventoryButtonHandlers[i].SetUpButton(this, i);
        }
    }    

    private void UpdateInventoryUI(List<InventoryItemData> _inventory)
    {
        inventory = _inventory;

        for (int i = 0; i < inventoryButtonHandlers.Length; i++)
        {
            if(i < inventory.Count)
            {
                inventoryItemIconImages[i].sprite = inventory[i].itemIcon;
                inventoryItemIconImages[i].enabled = true;
            }
            else
            {
                inventoryItemIconImages[i].sprite = null;
                inventoryItemIconImages[i].enabled = false;
            }
        }
    }

    #region ItemDescriptionUI

    /// <summary>
    /// Called from presses on the items in the inventory UI
    /// </summary>
    /// <param name="itemIndex"></param>
    public void ShowAndUpdateItemDescriptionUI(int itemIndex)
    {
        currentSelectedItemIndex = itemIndex;

        if(inventory.Count > 0)
        {
            if (itemIndex < inventory.Count)
            {
                itemNameText.text = inventory[itemIndex].itemName;
                itemDescriptionText.text = inventory[itemIndex].itemDescription;
                itemIconImage.sprite = inventory[itemIndex].itemIcon;

                if (inventory[itemIndex].isDropable)
                {
                    itemDropButton.enabled = true;
                }
                else
                {
                    itemDropButton.enabled = false;
                }

                itemDescriptionObject.SetActive(true);
            }
            else if(itemIndex >= inventory.Count)
            {
                itemDescriptionObject.SetActive(false);
            }

        }
    }

    public void DropInventoryItem()
    {
        playerView.PlayerInventory.DropItem(currentSelectedItemIndex);
        itemDescriptionObject.SetActive(false);
    }

    #endregion


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
        itemDescriptionObject.SetActive(false);
        inventoryAnimController.SetBool("ShowInventory", false);
    }

    #endregion
}
