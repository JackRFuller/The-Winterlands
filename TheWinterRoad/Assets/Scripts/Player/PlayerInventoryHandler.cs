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
    public event Action<InventoryItemData> ItemUpdatedInInventory;

    public bool CheckPlayerHasItem(string _itemName, int _numberRequired)
    {
        int numRequired = 0;

        for (int i = 0; i < Inventory.Count; i++)
        {
            if (Inventory[i].itemName == _itemName)
            {
                numRequired++;
                if (numRequired == _numberRequired)
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

        if(ItemUpdatedInInventory != null)
            ItemUpdatedInInventory(item);
    }

    public void RemoveItemFromInventory(InventoryItemData item)
    {
        Inventory.Remove(item);
        Debug.Log("Removed " + item);

        if (InventoryUpdated != null)
            InventoryUpdated(inventory);
    }

    public void DropItem(int itemIndex)
    {
        Vector2 offset = UnityEngine.Random.insideUnitCircle * 2f;
        Vector3 dropArea = new Vector3(transform.position.x + offset.x, transform.position.y + 1, transform.position.z + offset.y);     
        
        GameObject droppedItem = Instantiate(inventory[itemIndex].itemPrefab, dropArea, Quaternion.identity);

        RemoveItemFromInventory(inventory[itemIndex]);

        if (InventoryUpdated != null)
            InventoryUpdated(inventory);
    }

    public void EatItem(int itemIndex)
    {
        m_playerView.PlayerHealthHandler.RenewPlayerHealth(inventory[itemIndex].healthRenewalAmount);
        RemoveItemFromInventory(inventory[itemIndex]);

        if (InventoryUpdated != null)
            InventoryUpdated(inventory);
        
    }
	
}
