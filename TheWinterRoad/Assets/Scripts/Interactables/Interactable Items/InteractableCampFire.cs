using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableCampFire : Interactable
{    
    private List<BurningItem> burningItems;

    private float burnTime;
    private float burnIntensity;

    private int fireLevel = 0;
    [SerializeField]
    private Light fireLight;
    [SerializeField]
    private ParticleSystem fireParticles;

    [Header("UI Elements")]
    [SerializeField]
    private UICampfireHandler campfireUIHandler;

    public List<BurningItem> BurningItems
    {
        get
        {
            return burningItems;
        }       
    }
    public float BurnIntensity
    {
        get
        {
            return burnIntensity;
        }
      
    }
    public float BurnTime
    {
        get
        {
            return burnTime;
        }
    }

    public event Action CampfireActivated;
    public event Action CampfireInventoryUpdated;
    public event Action ItemsBeingBurnt;

    protected override void Start()
    {
        base.Start();

        burningItems = new List<BurningItem>();
        fireLight.intensity = 0;
        fireParticles.Stop();
    }

    private void Update()
    {
        BurnItems();
    }

    public override void InteractOne()
    {
        playerView.PlayerUIHandler.InventoryUIHandler.ReceiveActiveCampfire(this);

        if (CampfireActivated != null)
            CampfireActivated();
    }

    public void AddItemToCampfire(InventoryItemData item)
    {  
        if (burningItems.Count == 5)
            return;

        BurningItem burnItem = new BurningItem(item);

        burningItems.Add(burnItem);

        burnIntensity += item.burnIntensity;

        if (!fireParticles.isEmitting)
            fireParticles.Play();

        fireLight.intensity = burningItems.Count;

        if (CampfireInventoryUpdated != null)
            CampfireInventoryUpdated();
    }

    private void BurnItems()
    {
        if (burningItems.Count == 0)
            return;

        for (int burningItemIndex = 0; burningItemIndex < burningItems.Count; burningItemIndex++)
        {
            burningItems[burningItemIndex].elapsedBurnTime += Time.deltaTime;

            if(burningItems[burningItemIndex].elapsedBurnTime >= burningItems[burningItemIndex].burningItem.burnTime)
            {
                burnIntensity -= burningItems[burningItemIndex].burningItem.burnIntensity;
                burningItems.Remove(burningItems[burningItemIndex]);

                if (CampfireInventoryUpdated != null)
                    CampfireInventoryUpdated();
            }
        }

        //Calculate Burn Time Left
        float tempBurnTime = 0;

        for (int itemIndex = 0; itemIndex < burningItems.Count; itemIndex++)
        {
            float timeLeft = burningItems[itemIndex].burningItem.burnTime - burningItems[itemIndex].elapsedBurnTime;
            tempBurnTime += timeLeft;
        }

        burnTime = tempBurnTime;
        fireLight.intensity = burningItems.Count;

        if (burningItems.Count == 0)
        {
            burnTime = 0;
            burnIntensity = 0;

            if (fireParticles.isEmitting)
                fireParticles.Stop();
        }

        if (ItemsBeingBurnt != null)
            ItemsBeingBurnt();
    }

}

public class BurningItem
{
    public InventoryItemData burningItem;
    public float elapsedBurnTime = 0;

    public BurningItem(InventoryItemData _burningItem)
    {
        burningItem = _burningItem;
    }
}
