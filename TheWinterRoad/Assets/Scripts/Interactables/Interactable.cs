using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Interactable : Entity
{
    [SerializeField]
    protected InteractableItem interactable;
    protected UIInteractHandler uiInteractHandler;

    public InteractableItem InteractableItem
    {
        get
        {
            return interactable;
        }
    }

    public event Action<bool> PlayerWithinDistance;
    public event Action PlayerOutOfDistance;

    //Used if Interactable is Harvestable
    protected float interactProgress;

    protected virtual void Start()
    {
        this.gameObject.tag = "Interactable";
        uiInteractHandler = GetComponentInChildren<UIInteractHandler>();
        uiInteractHandler.SetupInteractUI(this);
    }

    public void PlayerWithinDistanceToInteract(bool canInteract)
    {
        if(PlayerWithinDistance != null)
        {
            PlayerWithinDistance(canInteract);
        }
    }

    public void PlayerOutOfDistanceToInteract()
    {
        if (PlayerOutOfDistance != null)
        {
            PlayerOutOfDistance();
        }
    }

    public virtual void Interact(PlayerView playerView)
    {

    }

    protected virtual void SpawnItem()
    {

    }


}
