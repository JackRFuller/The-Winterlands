using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableFire : Interactable
{
    private int fireLevel = 0;
    [SerializeField]
    private Light fireLight;
    [SerializeField]
    private ParticleSystem fireParticles;

    protected override void Start()
    {
        base.Start();

        fireLight.intensity = fireLevel;
        fireParticles.Stop();
    }

    public override void InteractOne()
    {
        fireLevel++;
        if (fireLevel > 4)
            fireLevel = 4;

        if (!fireParticles.isEmitting)
            fireParticles.Play();

        fireLight.intensity = fireLevel;

        playerView.PlayerInventory.RemoveItemFromInventory(interactableData.interacts[0].requiredInventoryItem.requiredInventoryItem);

    }

}
