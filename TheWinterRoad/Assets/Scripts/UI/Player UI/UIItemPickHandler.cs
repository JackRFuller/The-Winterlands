using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIItemPickHandler : UIPlayerHandler
{
	[SerializeField]
	private UIItemPickup[] itemPickUpUIs;

	public override void SetupPlayerUIHandler(PlayerView _playerView)
	{
		base.SetupPlayerUIHandler(_playerView);
		playerView.PlayerInventory.ItemUpdatedInInventory += PlayerPickedUpItem;
	}

	private void PlayerPickedUpItem(InventoryItemData pickedUpItem)
	{
		for (int itemUIIndex = 0; itemUIIndex < itemPickUpUIs.Length; itemUIIndex++)
		{
			if(!itemPickUpUIs[itemUIIndex].IsActive)
			{
				itemPickUpUIs[itemUIIndex].ShowItemPick(pickedUpItem);			
				break;
			}
			else
			{
				if(itemPickUpUIs[itemUIIndex].CurrentItem == pickedUpItem)
				{
					itemPickUpUIs[itemUIIndex].UpdateNumberOfItemsPickedUp(pickedUpItem);
					break;
				}					
			}
		}
	}	
}
