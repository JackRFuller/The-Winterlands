using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIInventoryButtonHandler : Entity
{
    private Button slotButton;
    private UIInventoryHandler uIInventoryHandler;
    private int itemSlotIndex;
    private int labelIndex;    

    public void SetUpButton(UIInventoryHandler _uIInventoryHandler, int _itemSlotIndex)
    {
        uIInventoryHandler = _uIInventoryHandler;
        itemSlotIndex = _itemSlotIndex;
        slotButton = GetComponent<Button>();
    }

    public void AssignItemIndex(int itemIndex)
    {
        labelIndex = itemIndex;
    }
    
    public void EnableButton()
    {
        slotButton.enabled = true;
    }

    public void DisableButton()
    {
        slotButton.enabled = false;
    }

    public void OnClick()
    {
        uIInventoryHandler.ShowAndUpdateItemDescriptionUI(itemSlotIndex);
    }
}
