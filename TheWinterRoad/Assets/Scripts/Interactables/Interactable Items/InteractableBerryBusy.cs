using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableBerryBusy : Interactable
{
	private Collider berryBushCollider;
	[SerializeField]
	private int renewalRateInDays = 1;
	private int renewalCount = 0;
	[SerializeField]
	private GameObject[] berries;




	protected override void Start()
	{
		base.Start();

		berryBushCollider = GetComponent<Collider>();		
		GameManager.Instance.TimeManager.NewDay += RenewBerries;		
	}

	public override void InteractOne()
	{
		for(int i = 0; i < interactableData.interacts[0].awardedInventoryItems[0].spawnRates.Length; i++)
		{
			float chanceOfDrop = Random.Range(0,100);
			if(chanceOfDrop < interactableData.interacts[0].awardedInventoryItems[0].spawnRates[i])
			{
				playerView.PlayerInventory.AddItemToInventory(interactableData.interacts[0].awardedInventoryItems[0].awardedInventoryItem);
			}
		}

		foreach(GameObject berry in berries)
		{
			berry.SetActive(false);
		}
		 this.gameObject.tag = "Null";
	}	

	private void RenewBerries()
	{
		renewalCount++;
		if(renewalCount >= renewalRateInDays)
		{
			foreach(GameObject berry in berries)
			{
				berry.SetActive(true);
			}
		}
		this.gameObject.tag = "Interactable";
	}
}
