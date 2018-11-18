using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIInventoryHandler : Entity
{
    private PlayerView playerView;
    private InteractableCampFire campFire;

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

    private InventoryMode inventoryMode = InventoryMode.InventoryManagement;
    private enum InventoryMode
    {
        InventoryManagement,
        Campfire,
    }

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

        for (int inventoryIndex = 0; inventoryIndex < inventoryButtonHandlers.Length; inventoryIndex++)
        {
            if(inventoryIndex < inventory.Count)
            {
                inventoryItemIconImages[inventoryIndex].sprite = inventory[inventoryIndex].itemIcon;
                inventoryItemIconImages[inventoryIndex].enabled = true;               
            }
            else
            {
                inventoryItemIconImages[inventoryIndex].sprite = null;
                inventoryItemIconImages[inventoryIndex].enabled = false;                
            }
        }
    }


    /// <summary>
    /// Called from individual inventory buttons
    /// </summary>
    /// <param name="itemIndex"></param>
    public void OnItemInInventoryClick(int itemIndex)
    {
        switch(inventoryMode)
        {
            case InventoryMode.InventoryManagement:
                ShowAndUpdateItemDescriptionUI(itemIndex);
                break;
            case InventoryMode.Campfire:
                AddBurnableObjectToCampfire(itemIndex);
                break;
        }
    }

    #region Campfire Inventory Management

    private void AddBurnableObjectToCampfire(int itemIndex)
    {
        campFire.AddItemToCampfire(inventory[itemIndex]);
        playerView.PlayerInventory.RemoveItemFromInventory(inventory[itemIndex]);
    }

    public void ReceiveActiveCampfire(InteractableCampFire _interactableCampFire)
    {
        campFire = _interactableCampFire;
    }

    #endregion

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
                PrepInventoryForManagement();
                RevealInventory();
                break;
            case InventoryState.Visible:
                HideInventory();
                break;
        }

    }

    public void RevealInventory()
    {
        playerView.PlayerUIHandler.PlayerOpenedAMenu();

        inventoryState = InventoryState.Visible;
        if (inventoryAnimController.enabled == false)
        {
            inventoryAnimController.enabled = true;
            return;
        } 

        inventoryAnimController.SetBool("ShowInventory", true);
    }

    public void HideInventory()
    {
        playerView.PlayerUIHandler.PlayerClosedAMenu();
        inventoryState = InventoryState.Hidden;
        itemDescriptionObject.SetActive(false);
        inventoryAnimController.SetBool("ShowInventory", false);
    }

    public void PrepInventoryForManagement()
    {
        for (int inventoryIndex = 0; inventoryIndex < inventoryButtonHandlers.Length; inventoryIndex++)
        {
            if(inventoryIndex < inventory.Count)
            {
                inventoryButtonHandlers[inventoryIndex].EnableButton();
            }
            else
            {
                inventoryButtonHandlers[inventoryIndex].DisableButton();
            }
        }

        inventoryMode = InventoryMode.InventoryManagement;
    }

    /// <summary>
    /// Shows inventory for campfire and disables any buttons for non burnable items
    /// </summary>
    public void PrepInventoryForCampfire()
    {
        for (int inventoryIndex = 0; inventoryIndex < inventory.Count; inventoryIndex++)
        {
            if (!inventory[inventoryIndex].isBurnable)
            {
                inventoryButtonHandlers[inventoryIndex].DisableButton();
                Color color = Color.white;
                color.a = 50;
                inventoryItemIconImages[inventoryIndex].color = color;
            }
            else
            {
                inventoryButtonHandlers[inventoryIndex].EnableButton();
            }
        }

        inventoryMode = InventoryMode.Campfire;
        RevealInventory();
    }

    #endregion
}
