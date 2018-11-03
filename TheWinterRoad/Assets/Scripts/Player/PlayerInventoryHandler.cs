using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInventoryHandler : PlayerHandler
{
    [SerializeField]
    private List<InventoryItemData> inventory;

    public List<InventoryItemData> Inventory
    {
        get
        {
            return inventory;
        }       
    }

    public event Action<List<InventoryItemData>> InventoryUpdated;   

    public bool CheckPlayerHasItem(string _itemName, int _numberRequired)
    {
        int numRequired = 0;

        for (int i = 0; i < Inventory.Count; i++)
        {
            if(Inventory[i].itemName == _itemName)
            {
                numRequired++;
                if(numRequired == _numberRequired)
                {
                    return true;
                }
            }
        }

        return false;
    }

    public void AddItemToInventory(InventoryItemData item)
    {
        Inventory.Add(item);
        Debug.Log("Added " + item);

        if (InventoryUpdated != null)
            InventoryUpdated(inventory);
    }

    public void RemoveItemFromInventory(InventoryItemData item)
    {
        Inventory.Remove(item);
        Debug.Log("Removed " + item);

        if (InventoryUpdated != null)
            InventoryUpdated(inventory);
    }
	
}
