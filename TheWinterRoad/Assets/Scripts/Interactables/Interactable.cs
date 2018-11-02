using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Interactable : Entity
{
    [SerializeField]
    protected InteractableItemData interactableData;    
    public InteractableItemData InteractableItem
    {
        get
        {
            return interactableData;
        }
    }

    protected PlayerView playerView;
    protected int interactIndex;

    //Used if Interactable is Harvestable
    protected float interactProgress;

    protected virtual void Start()
    {
        this.gameObject.tag = "Interactable";
    }

    public virtual void Interact(int _interactIndex, PlayerView _playerView)
    {
        playerView = _playerView;
        interactIndex = _interactIndex;

        switch (interactIndex)
        {
            case 0:
                InteractOne();
                break;
            case 1:
                InteractTwo();
                break;
            case 2:
                InteractThree();
                break;
        }

    }

    public virtual void InteractOne()
    {

    }

    public virtual void InteractTwo()
    {

    }

    public virtual void InteractThree()
    {

    }

    protected virtual void SpawnItem()
    {

    }


}
