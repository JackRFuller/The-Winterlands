using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableTree : Interactable
{
    [SerializeField]
    private Transform itemSpawnPoint;

    public override void Interact(PlayerView playerView)
    {
        interactProgress++;
        uiInteractHandler.SetInteractableProgress(interactProgress);

        if(interactProgress == interactable.numberOfNeededInteracts)
        {
            SpawnItem();
        }
    }

    protected override void SpawnItem()
    {
        for (int harvestableItemIndex = 0; harvestableItemIndex < interactable.harvestableItems.Length; harvestableItemIndex++)
        {
            for (int spawnRateIndex = 0; spawnRateIndex < interactable.harvestableItems[harvestableItemIndex].spawnRates.Length; spawnRateIndex++)
            {
                float chanceOfDrop = Random.Range(0, 100);
                if(chanceOfDrop < interactable.harvestableItems[harvestableItemIndex].spawnRates[spawnRateIndex])
                {
                    Instantiate(interactable.harvestableItems[harvestableItemIndex].inventoryItem.itemPrefab, itemSpawnPoint.position, itemSpawnPoint.rotation);
                }
            }
        }

        this.gameObject.SetActive(false);
    }
}
