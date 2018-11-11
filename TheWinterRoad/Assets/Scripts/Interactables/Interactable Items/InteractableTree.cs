using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableTree : Interactable
{  
    [SerializeField]
    public CameraShake.Properties cameraShakeProperties;

    public override void InteractOne()
    {
        interactProgress++;

        //GameManager.Instance.CameraView.CameraShake.StartShake(cameraShakeProperties);

        if (interactProgress == interactableData.interacts[interactIndex].numberofRequiredInteracts)
        {
            SpawnItem();
        }
    }

    protected override void SpawnItem()
    {
        for (int inventoryItemIndex = 0; inventoryItemIndex < interactableData.interacts[interactIndex].awardedInventoryItems.Length; inventoryItemIndex++)
        {
            for (int spawnRateIndex = 0; spawnRateIndex < interactableData.interacts[0].awardedInventoryItems[inventoryItemIndex].spawnRates.Length; spawnRateIndex++)
            {
                float chanceOfDrop = Random.Range(0, 100);
                if (chanceOfDrop < interactableData.interacts[0].awardedInventoryItems[inventoryItemIndex].spawnRates[spawnRateIndex])
                {
                    Vector2 offset = UnityEngine.Random.insideUnitCircle * 1.5f;
                    Vector3 dropArea = new Vector3(transform.position.x + offset.x, transform.position.y + 2, transform.position.z + offset.y);

                    Instantiate(interactableData.interacts[0].awardedInventoryItems[inventoryItemIndex].awardedInventoryItem.itemPrefab, dropArea, Quaternion.identity);
                }
            }
        }

        this.gameObject.SetActive(false);
    }
}
