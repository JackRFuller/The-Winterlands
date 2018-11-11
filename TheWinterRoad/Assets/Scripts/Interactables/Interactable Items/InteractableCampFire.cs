using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableCampFire : Interactable
{
    private int fireLevel = 0;
    [SerializeField]
    private Light fireLight;
    [SerializeField]
    private ParticleSystem fireParticles;

    [Header("UI Elements")]
    [SerializeField]
    private UICampfireHandler campfireUIHandler;

    public event Action CampfireActivated;

    protected override void Start()
    {
        base.Start();

        fireLight.intensity = fireLevel;
        fireParticles.Stop();
    }

    public override void InteractOne()
    {
        if (CampfireActivated != null)
            CampfireActivated();

        //fireLevel++;
        //if (fireLevel > 4)
        //    fireLevel = 4;

        //if (!fireParticles.isEmitting)
        //    fireParticles.Play();

        //fireLight.intensity = fireLevel;

        //playerView.PlayerInventory.RemoveItemFromInventory(interactableData.interacts[0].requiredInventoryItem.requiredInventoryItem);

    }

}
