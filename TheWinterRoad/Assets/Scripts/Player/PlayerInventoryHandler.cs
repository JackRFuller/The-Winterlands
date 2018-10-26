using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInventoryHandler : PlayerHandler
{
    [SerializeField]
    private List<InventoryItem> inventory;

    public List<InventoryItem> Inventory
    {
        get
        {
            return inventory;
        }       
    }

    public event Action<InventoryItem,int> ItemAddedToInventory;

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

    public void AddItemToInventory(InventoryItem item)
    {
        Inventory.Add(item);
        Debug.Log("Added " + item);

        if (ItemAddedToInventory != null)
            ItemAddedToInventory(item,Inventory.Count);
    }
	
}
