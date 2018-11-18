using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIItemPickup : MonoBehaviour
{
	private InventoryItemData currentItem;
	private bool isActive;

	public Image itemPickupImage;
	public TMP_Text itemNameText;
	public Image itemIconImage;
	private IEnumerator coroutine;
	private int numberOfItemsPickedUp = 0;
	private float waitToTurnOffTime = 3.0f;

    public InventoryItemData CurrentItem
    {
        get
        {
            return currentItem;
        }        
    }
    public bool IsActive
    {
        get
        {
            return isActive;
        }
    }

	private void Start()
	{
		TurnOffLabel();	
	}

	private void TurnOffLabel()
	{
		isActive = false;
		itemPickupImage.enabled = false;
		itemNameText.enabled = false;
		itemIconImage.enabled = false;

		numberOfItemsPickedUp = 0;
		currentItem = null;
	}

	private void TurnOnLabel()
	{
		isActive = true;
		itemPickupImage.enabled = true;
		itemNameText.enabled = true;
		itemIconImage.enabled = true;
	}

    public void ShowItemPick(InventoryItemData item)
	{	
		if(coroutine == null)
			coroutine = TurnOffItemPickUpLabel();

		currentItem = item;
		
		itemIconImage.sprite = item.itemIcon;
		numberOfItemsPickedUp++;		
		string itemLabel = numberOfItemsPickedUp.ToString() + " " + item.itemName;
		itemNameText.text = itemLabel;

		TurnOnLabel();

		StartCoroutine(TurnOffItemPickUpLabel());	
	}

	public void UpdateNumberOfItemsPickedUp(InventoryItemData item)
	{
		numberOfItemsPickedUp++;		
		string itemLabel = numberOfItemsPickedUp.ToString() + " " + item.itemName;
		itemNameText.text = itemLabel;
	}

	private IEnumerator TurnOffItemPickUpLabel()
	{
		yield return new WaitForSeconds(waitToTurnOffTime);
		TurnOffLabel();		
	}
}
